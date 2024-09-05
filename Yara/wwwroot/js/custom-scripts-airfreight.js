// =============== COMMON =============================
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

// ======================= DATA TABLES =======================
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
$(function () {
    $("#example5").DataTable().fnDestroy();
    $('#example5').DataTable({
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
// ======================= DATA TABLES =======================










// =============== COMMON =============================


// ======================= Chat =======================

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

    const response = await fetch("/AirFreight/chat/uploadFile", {
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

// ======================= Chat =======================

// ======================= Customer Message =======================
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
// ======================= Customer Message =======================

// ======================= FAQ =======================
$(document).ready(function () {
    $("#accordion-1").accordion({
        collapsible: true,
        active: false
    });
});
// ======================= FAQ =======================
// ======================= Order New =======================
$(document).ready(function () {
    // Bind change event to the selected company
    $('#selectedcompany').change(function () {
        console.log("Selected company changed");
        updateCosting();
    });
    // Bind change event to the selected company
    $('#toCurrency').change(function () {
        console.log("Selected currency changed");
        updateCosting();
    });

    // Bind input event to the weight field
    $('#weight').on('input', function () {
        updateCosting();
    });

    function updateCosting() {
        const selectedCompany = $('#selectedcompany').val();
        const weight = parseFloat($('#weight').val());
        const toCurrency = $('#toCurrency').val();

        if (isNaN(weight) || weight <= 0) {
            console.log("Invalid weight value");
            $('#costPrice').val('');
            $('#price').val('');
            return;
        }

        console.log("Selected company is: ", selectedCompany);
        console.log("Weight is: ", weight);
        console.log("toCurrency is: ", toCurrency);

        $.ajax({
            url: '@Url.Action("GetPrices", "OrderNew")',
            data: { selectedCompanyId: selectedCompany, weight: weight, toCurrencyId: toCurrency, fromCurrencyId: 1 },
            success: function (data) {
                console.log("AJAX success, data: ", data);
                if (data) {
                    $('#costPrice').val(data.costPrice);
                    $('#price').val(data.price);
                    $('#exchangePrice').val(data.exchangePrice);
                    // calculatePrice();
                } else {
                    $('#costPrice').val('');
                    $('#price').val('');
                    $('#exchangePrice').val('');
                }
            },
            error: function () {
                alert('Error! Please try again.');
                console.log("AJAX error");
            }
        });
    }

    function calculatePrice() {
        const weight = parseFloat($('#weight').val());
        const costPrice = parseFloat($('#costPrice').val());

        if (isNaN(weight) || isNaN(costPrice)) {
            console.log("Invalid weight or cost price");
            $('#price').val('');
            return;
        }

        const price = weight * costPrice;
        $('#price').val(price);
    }
});
// ======================= Order New =======================
// ======================= Paidings =======================
$(document).ready(function () {
    // console.log("Document is ready");
    // $('.select2_1').select2({
    //     placeholder: "Select an option",
    //     allowClear: true
    // });
    // Bind change event to the selected company
    $('#orderId').change(function () {
        updateCosting(false);
    });
    // Bind change event to the selected company
    $('#toCurrency').change(function () {
        updateCosting(false);
    });
    // Bind change event to the revisedMoney input field
    $('#revisedMoney').on('input', function () {
        updateCosting(true); // Pass true to indicate manual input
    });

    function updateCosting(isManual) {

        const orderId = $('#orderId').val();
        const revisedMoney = $('#revisedMoney').val();
        const toCurrency = $('#toCurrency').val();

        console.log("Updating costing");
        console.log("isManual: ", isManual);
        console.log("orderId: ", orderId);
        console.log("revisedMoney: ", revisedMoney);
        console.log("toCurrency: ", toCurrency);

        $.ajax({
            url: '@Url.Action("GetOrderDetails", "Paidings")',
            data: {
                toCurrencyId: toCurrency,
                fromCurrencyId: 1,
                revisedMoney: revisedMoney,
                orderId: orderId,
                isManual: isManual
            },
            success: function (data) {
                console.log("AJAX success, data: ", data);
                if (data) {
                    $('#exchangePrice').val(data.exchangedPrice);
                    // $('#revisedMoney').val(data.revisedMoney);
                    if (!isManual) {
                        $('#revisedMoney').val(data.revisedMoney);
                    }
                } else {
                    $('#exchangePrice').val('');
                    $('#revisedMoney').val('');
                }
            },
            error: function () {
                alert('Error! Please try again.');
                console.log("AJAX error");
            }
        });
    }
});
// ======================= Paidings =======================

// ======================= Transfer =======================
$(document).ready(function () {
    // Bind change event to the selected company
    $('#paidingId').change(function () {
        updateCosting(false);
    });
    // Bind change event to the selected company
    $('#toCurrency').change(function () {
        updateCosting(false);
    });
    // Bind change event to the revisedMoney input field
    $('#revisedMoney').on('input', function () {
        updateCosting(true); // Pass true to indicate manual input
    });

    function updateCosting(isManual) {

        const paidingId = $('#paidingId').val();
        const revisedMoney = $('#revisedMoney').val();
        const toCurrency = $('#toCurrency').val();

        console.log("Updating costing");
        console.log("isManual: ", isManual);
        console.log("paidingId: ", paidingId);
        console.log("revisedMoney: ", revisedMoney);
        console.log("toCurrency: ", toCurrency);

        $.ajax({
            url: '@Url.Action("GetOrderDetails", "Transfer")',
            data: {
                toCurrencyId: toCurrency,
                fromCurrencyId: 1,
                revisedMoney: revisedMoney,
                paidingId: paidingId,
                isManual: isManual
            },
            success: function (data) {
                console.log("AJAX success, data: ", data);
                if (data) {
                    $('#exchangePrice').val(data.exchangedPrice);
                    // $('#revisedMoney').val(data.revisedMoney);
                    if (!isManual) {
                        $('#revisedMoney').val(data.revisedMoney);
                    }
                } else {
                    $('#exchangePrice').val('');
                    $('#revisedMoney').val('');
                }
            },
            error: function () {
                alert('Error! Please try again.');
                console.log("AJAX error");
            }
        });
    }
});
// ======================= Transfer =======================