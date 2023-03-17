$(document).ready(function () {
    // Get the end date in the desired format
    var endDateStr = $("#timeShowUp").text();

    // Parse the end date string into a Date object
    var endDate = moment(endDateStr, "h:mm:ss DD/MM/YYYY");

    // Update the countdown every second
    setInterval(function () {
        // Calculate the time remaining in seconds
        var now = moment();
        var secondsRemaining = Math.floor(endDate.diff(now) / 1000);

        // Calculate the time remaining in days, hours, minutes, and seconds
        var days = Math.floor(secondsRemaining / (24 * 60 * 60));
        var hours = Math.floor((secondsRemaining % (24 * 60 * 60)) / (60 * 60));
        var minutes = Math.floor((secondsRemaining % (60 * 60)) / 60);
        var seconds = secondsRemaining % 60;

        // Format the time remaining as a string
        var countdownStr = days + " days, " + hours + " hours, " + minutes + " minutes, " + seconds + " seconds";

        // Update the countdown display
        $("#countdown").text(countdownStr);
        if (secondsRemaining < 0) {
            clearInterval(x);
            $("#countdown").html("The match is on live now");
        }
    }, 1000);
});