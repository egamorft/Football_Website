$(document).ready(function () {
    var connection = new signalR.HubConnectionBuilder().withUrl("/matchcenterhub").build();
    console.log(connection);
    loadMatches();
    connection.on("RefreshMatchCentre", function (match) {
        console.log("rload");
        loadMatches();
    });
    connection.start().then().catch(function (err) {
        return console.log(err.toString());
    });
});

function loadMatches() {
    $.get("https://localhost:5000/api/Match/Happening", null, function (response) {
        bindMatches(response);
    });
}

function bindMatches(matches) {
    var html = "";
    $("#listMatches").html("");
    $.each(matches,
        function (index, match) {
            html += "<tr data-match-id='" + match.matchesId + "'>";

            html += "<td>";
            html += "<img style='width: 50%;' class='card-img img-fluid img-thumbnail align-self-center' src='/img/clubs-logos/" + match.team1Logo + "'/>";
            html += "<span class='team-name'>" + match.team1Name + "</span>";
            html += "</td>";

            html += "<td>";
            html += "<span data-team-id='" + match.team1ID + "' class='team-goals'>" + match.team1Goal + "</span>";
            html += "</td>";

            html += "<td>";
            html += "<span class='team-separator'> — </span>";
            html += "</td>";

            html += "<td>";
            html += "<span data-team-id='" + match.team2ID + "' class='team-goals'>" + match.team2Goal + "</span>";
            html += "</td>";

            html += "<td>";
            html += "<img style='width: 50%;' class='card-img img-fluid img-thumbnail align-self-center' src='/img/clubs-logos/" + match.team2Logo + "'/>";
            html += "<span class='team-name'>" + match.team2Name + "</span>";
            html += "</td>";

            html += "</tr>";
        });
    $("#listMatches").append(html);
}