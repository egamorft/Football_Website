// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var connection = new signalR.HubConnectionBuilder().withUrl("/matchcenterhub").build();
$(document).ready(function () {
    loadMatches();
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
            html += "<input type='button' class='btn btn-success' value='Add Goal' data-match-id='" + match.matchesId + "' data-team-1-id='" + match.team1ID + "' onclick='addGoal(this);' />";
            html += "</td>";

            html += "<td>";
            html += "<span class='team-separator'> — </span>";
            html += "</td>";

            html += "<td>";
            html += "<span data-team-id='" + match.team2ID + "' class='team-goals'>" + match.team2Goal + "</span>";
            html += "<input type='button' class='btn btn-success' value='Add Goal' data-match-id='" + match.matchesId + "' data-team-2-id='" + match.team2ID + "' onclick='addGoal(this);' />";

            html += "</td>";

            html += "<td>";
            html += "<img style='width: 50%;' class='card-img img-fluid img-thumbnail align-self-center' src='/img/clubs-logos/" + match.team2Logo + "'/>";
            html += "<span class='team-name'>" + match.team2Name + "</span>";
            html += "</td>";

            html += "</tr>";
        });
    $("#listMatches").append(html);
}

function addGoal(element) {
    var data =
    {
        MatchesId: $(element).attr("data-match-id"),
        Team1ID: $(element).attr("data-team-1-id"),
        Team2ID: $(element).attr("data-team-2-id")
    }
    var JwtToken = $("#JwtToken:hidden").val();
    console.log(data);
    $.ajax({
        type: 'PUT',
        url: 'https://localhost:5000/api/Match/Happening/Edit',
        contentType: 'application/json',
        data: JSON.stringify(data),
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + JwtToken);
        },
        error: (error) => {
            console.log(error)
        },
    }).done(function () {
        loadMatches();

        connection.invoke("SendMatchCentreUpdate").catch(function (err) {
            return console.error(err.toString());
        });
    });
}