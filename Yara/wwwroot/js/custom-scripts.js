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
// =============== ResourceWebAr.LBMyArea =================


// ==================== Admin Chat ====================

// SignalR Chat Initialization
let connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Handle receiving messages from the server
connection.on("ReceiveMessage", function (user, message, pathImg, img, time) {
    appendMessage(user, message, pathImg, img, time);
});

// Function to send a message
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

    connection.invoke("SendMessageToClients", message, to, filePath).then(() => {
        // Append the message to the message list in the UI
        appendMessage('@ViewBag.UserId', message, filePath, '@ViewBag.img', new Date().toLocaleTimeString());
    }).catch(function (err) {
        console.error("Error sending message:", err.toString());
    });
}

// Function to upload a file to the server
async function uploadFile(file) {
    const formData = new FormData();
    formData.append("file", file);

    const response = await fetch("/Admin/chat/uploadFile", {
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

// Function to append the message to the chat UI
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

// Start the SignalR connection
connection.start().catch(function (err) {
    return console.error(err.toString());
});

// Scroll the chat to the bottom on window load
window.onload = function () {
    scrollToBottom();
}

// Function to scroll the chat to the bottom
function scrollToBottom() {
    const messagesList = document.getElementById("messagesList");
    messagesList.scrollTop = messagesList.scrollHeight;
}

// ==================== Admin Chat ====================
// ==================== Own Chat ====================




// ==================== Own Chat ====================