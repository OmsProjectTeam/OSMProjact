// ==================== ResourceWeb.LBAddArea ====================
var loadFile = function (event) {
    var image = document.getElementById('output');
    image.src = URL.createObjectURL(event.target.files[0]);
};

// Function to set the current URL in a hidden input
$(document).ready(function () {
    $("#url").val(window.location.href);
});

// =============== ResourceWebAr.LBMyArea =================
// Function to truncate text to a specified length
function truncateText(text, maxLength) {
    if (text.length > maxLength) {
        return text.substring(0, maxLength) + '...'; // Add ellipsis if text exceeds maxLength
    } else {
        return text;
    }
}

// Apply truncation on document ready
$(document).ready(function () {
    $('.truncate-50').each(function () {
        var text = $(this).text(); // Get the text content of the cell
        var truncatedText = truncateText(text, 100); // Truncate the text to 50 characters
        $(this).text(truncatedText); // Set the truncated text back to the cell
    });
});

// Destroy and reinitialize DataTable for #example2
$(function () {
    $("#example2").DataTable().fnDestroy();
    $('#example2').DataTable({
        "paging": false,
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false,
    });
});

// Destroy and reinitialize DataTable for #example3
$(function () {
    $("#example3").DataTable().fnDestroy();
    $('#example3').DataTable({
        "paging": false,
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false,
    });
});