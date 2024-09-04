// =============  COMMON  =============
var loadFile = function (event) {
    var image = document.getElementById('output');
    image.src = URL.createObjectURL(event.target.files[0]);
};
$("#url").val(window.location.href);

$(document).ready(function () {
    $('.select2_1').select2({
        placeholder: "Select an option",
        allowClear: true
    });

    $('#merchant-select').change(function () {
        var userId = $(this).val();
        if (userId) {
            $.getJSON('@Url.Action("GetUserDetails", "CustomerMessages")', { id: userId }, function (data) {
                $('input[name="CustomerMessages.CompanyName"]').val(data.companyName);
                $('input[name="CustomerMessages.PhoneCompany"]').val(data.phoneCompany);
                $('input[name="CustomerMessages.PhoneCompanySecand"]').val(data.phoneCompanySecand);
                $('input[name="CustomerMessages.EmailCompany"]').val(data.emailCompany);

            });
        }
    });
});

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

$(document).ready(function () {
    // Function to truncate text to a specified length
    function truncateText(text, maxLength) {
        if (text.length > maxLength) {
            return text.substring(0, maxLength) + '...'; // Add ellipsis if text exceeds maxLength
        } else {
            return text;
        }
    }

    // Loop through each table cell with class 'truncate-50'
    $('.truncate-50').each(function () {
        var text = $(this).text(); // Get the text content of the cell
        var truncatedText = truncateText(text, 100); // Truncate the text to 50 characters
        $(this).text(truncatedText); // Set the truncated text back to the cell
    });
});
// =============  COMMON  =============

// ==================== CHAT ====================

let connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("ReceiveMessage", function (user, message, pathImg, img, time) {
    appendMessage(user, message, pathImg, img, time);
});

async function sendMessage() {
    const message = document.getElementById("messageInput1").value;
    const to = document.getElementById("sendTo").value;

    if (!to) {
        console.error("Recipient name (to) is null or undefined. Cannot send message.");
        alert("Please select a user to chat with.");
        return;
    }

    const fileInput = document.getElementById("ImgSend");
    let filePath = null;
    if (fileInput && fileInput.files.length > 0) {
        const file = fileInput.files[0];
        try {
            filePath = await uploadFile(file);
        } catch (error) {
            console.error("Error uploading file:", error);
            return;
        }
    }

    document.getElementById("messageInput1").value = "";

    connection.invoke("SendMessageToAdmin", message, to, filePath).then(() => {
        // Append the message to the message list in the UI
        appendMessage('@ViewBag.UserId', message, filePath, '@ViewBag.img', new Date().toLocaleTimeString());
    }).catch(function (err) {
        console.error("Error sending message:", err.toString());
    });
}

async function uploadFile(file) {
    const formData = new FormData();
    formData.append("file", file);

    const response = await fetch("/ClintAccount/chat/uploadFile", {
        method: "POST",
        body: formData
    });

    if (response.ok) {
        const data = await response.json();
        return data.filePath;
    } else {
        throw new Error("File upload failed");
    }
}

function appendMessage(user, message, pathImg, img, time) {
    const messageList = document.getElementById("messagesList");
    const isSender = user === '@ViewBag.UserId'; // Compare with the current user's ID or name
    const messageDiv = document.createElement("div");
    messageDiv.classList.add("message", isSender ? "sent" : "received");

    let content = `<div class="message-content">${message}</div><div class="message-time">${time}</div>`;

    // If there is an image attached to the message, add it to the content
    if (pathImg) {
        content = `<img src="${pathImg}" alt="Image message" class="message-image" />` + content;
    }

    messageDiv.innerHTML = content;
    messageList.appendChild(messageDiv);
    messageList.scrollTop = messageList.scrollHeight; // Scroll to the bottom after adding the message
}

connection.start().catch(function (err) {
    return console.error(err.toString());
});

window.onload = function () {
    scrollToBottom();
}

function scrollToBottom() {
    const messagesList = document.getElementById("messagesList");
    messagesList.scrollTop = messagesList.scrollHeight;
}

// ==================== END CHAT ====================

// ==================== Customer Message ====================
$(document).ready(function () {
    $('#city-select').change(function () {
        var cityId = $(this).val();
        if (cityId) {
            $.getJSON('@Url.Action("GetAreasByCity", "CityDeliveryTariffs")', { cityId: cityId }, function (data) {
                var $areaSelect = $('#area-select');
                $areaSelect.empty();
                $.each(data, function (index, item) {
                    $areaSelect.append($('<option>', {
                        value: item.id,
                        text: item.description
                    }));
                });
            });
        } else {
            $('#area-select').empty();
        }
    });
});
// ==================== END Customer Message ====================

// ==================== FAQ ====================
$(document).ready(function () {
    $("#accordion-1").accordion({
        collapsible: true,
        active: false
    });
});
// ==================== END FAQ ====================