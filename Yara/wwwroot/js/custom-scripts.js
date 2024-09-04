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

// ==================== My Check Customer ====================
$(document).ready(function () {
    $('#phoneSearchForm').on('submit', function (e) {
        e.preventDefault(); // Prevent default form submission

        var phoneNumber = $('#phoneNo').val();
        $.ajax({
            url: '@Url.Action("GitPhouneNumber", "CheckCustmer", new { area = "Admin" })',
            type: 'POST',
            data: { PhoneNumber: phoneNumber },
            success: function (response) {
                console.log('Response Received:', response);

                if (response && response.success) {
                    // const description = response.description || 'No description available';
                    // // Split the description by ' -- ' to get each key-value pair
                    // let descriptionParts = description.split(' -- ');

                    $('#descriptionContent').empty();

                    // Loop through each part and create the button and input
                    // descriptionParts.forEach(part => {
                    //     let [label, value] = part.split(':').map(s => s.trim());

                    //     // Create button element for the label
                    //     let labelButton = `<button type="button" class="description-button">${label}</button>`;

                    //     // Create read-only input field for the value
                    //     let valueInput = `<input type="text" class="description-input" value="${value}" readonly style="margin-left: 10px; margin-bottom: 10px;">`;

                    //     // Append the button and input to the description box
                    //     $('#descriptionBox').append(`<div class="description-row">${labelButton}${valueInput}</div>`);
                    // });

                    $('#clientName').text(response.name || 'N/A');
                    $('#city').text(response.city || 'N/A');
                    $('#area').text(response.area || 'N/A');
                    $('#landmark').text(response.landmark || 'N/A');
                    $('#nikeName').text(response.nikeName || 'N/A');
                    $('#cityDeliveryTariff').text(response.cityDeliveryTariff || 'N/A');
                    $('#currency').text(response.currency || 'N/A');
                    $('#custPriceOver10').text(response.custPriceOver10 || 'N/A');
                    $('#custPriceUnder10').text(response.custPriceUnder10 || 'N/A');
                    $('#dealingStatus').text(response.dealingStatus || 'N/A');
                    $('#phoneNumber').text(response.phoneNumber || 'N/A');
                    $('#system').text(response.system || 'N/A');

                    $('#descriptionBox').show();
                    $('#descriptionBox2').show();

                    // Format the description for display
                    // let formattedDescription = descriptionParts.map(part => {
                    //     let [label, value] = part.split(':').map(s => s.trim());
                    //     return `${label}: ${value}`;
                    // }).join('\n');


                    // Set the formatted description in the textarea
                    // $('#shippingDescription').val(formattedDescription);
                    // $('#descriptionBox').show(); // Display the textarea


                    // $('#shippingDescription').val(description);
                    // $('#shippingDescription').closest('.col-lg-6').show(); // Display the textarea
                    // $('#errorMessage').text('');

                    // Display a success message if a new customer was registered
                    if (response.message) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Success',
                            text: response.message,
                            showConfirmButton: false,
                            timer: 2000 // Auto-close after 2 seconds
                        }).then(() => {
                            // Add the new client to the client dropdown
                            $('#clintName').append(new Option(response.name, response.userId, true, true));
                            // Open the modal after the success message
                            setTimeout(() => {
                                $('#customModal').show();
                            }, 500); // Delay of 1 second before opening the modal
                        });
                    }
                } else {
                    // SweetAlert for description not found
                    Swal.fire({
                        icon: 'warning',
                        title: 'No Description Found',
                        text: 'Do you want to add a new address?',
                        showCancelButton: true,
                        confirmButtonText: 'Yes, add address',
                        cancelButtonText: 'No',
                    }).then((result) => {
                        if (result.isConfirmed) {
                            // The user wants to add a new address, open the modal
                            $('#customModal').show();
                        }
                    });
                }
            },
            error: function () {
                $('#shippingDescription').closest('.col-lg-6').hide(); // Hide the textarea if there was an error
                $('#errorMessage').text('An error occurred while processing your request.');
            }
        });
    });

    // Function to close the modal
    function closeModal() {
        $('#customModal').hide();
    }

    // Attach the closeModal function to the close button
    $('.close-modal').on('click', closeModal);

    // Open the modal when "Add New Address" button is clicked
    $('#addNewAddressButton').on('click', function () {
        $('#customModal').show();
    });
});
$(document).ready(function () {
    $('#city-select').change(function () {
        var cityId = $(this).val();
        if (cityId) {
            $.getJSON('@Url.Action("GetAreasByCity", "ShippingAddresseClint")', { cityId: cityId }, function (data) {
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
$(document).ready(function () {
    $('#nike-name-select').change(function () {
        console.log('Nike name changed');  // Check if the event is firing

        var shippingPriceId = $(this).val();
        console.log('Selected Shipping Price ID:', shippingPriceId);  // Log the selected ID

        if (shippingPriceId) {
            var url = '@Url.Action("GetShippingPricesByNikeName", "ShippingAddresseClint", new { area = "Admin" })';
            console.log('Request URL:', url);  // Log the request URL

            $.getJSON(url, { shippingPriceId: shippingPriceId }, function (data) {
                console.log('Received Data:', data);  // Log the received data

                if (data) {
                    $('#price-under-10').val(data.coPricePerkgUnder10);
                    $('#price-above-10').val(data.coPricePerkgAbove10);
                } else {
                    console.log('No data received or data is null');
                }
            }).fail(function (jqxhr, textStatus, error) {  // Handle errors
                console.error('Request Failed:', textStatus, error);
            });
        } else {
            console.log('No Shipping Price ID selected');
        }
    });
});
$(document).ready(function () {
    $('#delivery-tarrif-select').change(function () {
        console.log('Delivery name changed');  // Check if the event is firing

        var typeSystemId = $(this).val();
        console.log('Selected Shipping Price ID:', typeSystemId);  // Log the selected ID

        if (typeSystemId) {
            var url = '@Url.Action("GetDeliveryDetailsByTypeSystem", "ShippingAddresseClint", new { area = "Admin" })';
            console.log('Request URL:', url);  // Log the request URL

            $.getJSON(url, { typeSystemId: typeSystemId }, function (data) {
                console.log('Received Data:', data);  // Log the received data

                if (data) {
                    $('#delivery-company').val(data.companyPricing);
                    $('#delivery-client').val(data.deliveryPriceClint);
                } else {
                    console.log('No data received or data is null');
                }
            }).fail(function (jqxhr, textStatus, error) {  // Handle errors
                console.error('Request Failed:', textStatus, error);
            });
        } else {
            console.log('No Shipping Price ID selected');
        }
    });
});
$(document).ready(function () {
    function updateDeliveryPriceClint() {
        // Clear the existing value before updating
        $('#delivery-price-clint').val('');

        // Get the text of the selected option for Clint Name
        var clintName = $('#clintName option:selected').text() || 'N/A';
        var city = $('#city-select option:selected').text() || 'N/A';
        var area = $('#area-select option:selected').text() || 'N/A';
        var landmark = $('#landmark').val() || 'N/A';
        var nikeName = $('#nike-name-select option:selected').text() || 'N/A';
        var under10 = $('#shipping-under-10').val() || 'N/A';
        var above10 = $('#shipping-above-10').val() || 'N/A';
        var system = $('#type-system-select option:selected').text() || 'N/A';
        var localDescription = $('#local-delivery-description').val() || 'N/A';
        var dealingStatus = $('#dealing-status').val() || 'N/A';
        var deliveryCustomer = $('#delivery-customer').val() || 'N/A';
        var exchangePrice = $('#type-system-select option:selected').val() || 'N/A';

        // Combine the values in the correct order
        var combined = `Clint Name: ${clintName} -- City Name: ${city} -- Area Name: ${area} -- Landmark: ${landmark} -- Customer shipping price is less than 10: ${under10} -- Customer shipping price is more than 10: ${above10} -- Nick name: ${nikeName} -- System: ${system} -- Delivery price to the customer: ${deliveryCustomer} -- exchange: ${exchangePrice} -- Dealing status: ${dealingStatus}`;

        // Set the combined string to the delivery price field
        $('#delivery-price-clint').val(combined);
    }

    // Attach the function to the change and input events
    $('#clintName, #city-select, #area-select, #nike-name-select, #type-system-select').change(updateDeliveryPriceClint);
    $('#description, #landmark, #price-under-10, #price-above-10, #local-delivery-description, #dealingStatus, #deliveryCustomer, #exchangePrice').on('input', updateDeliveryPriceClint);
});
$(document).ready(function () {
    // Function to open modal and populate client name
    function openModalWithClientName() {
        var clientName = '@TempData["ClientName"]';
        if (clientName) {
            $('#clintName').val(clientName);
        }
        $('#customModal').show();
    }

    // Attach the function to the event when "Add New Address" button is clicked
    $('#addNewAddressButton').on('click', openModalWithClientName);

    // Function to close the modal
    function closeModal() {
        $('#customModal').hide();
    }

    // Attach the closeModal function to the close button
    $('.close-modal').on('click', closeModal);
});
$(document).ready(function () {
    // Function to open the New Order Modal
    function openNewOrderModal() {
        $('#newOrderCustomModal').show();
    }

    // Attach the function to the Add New Order button
    $('#addNewOrderButton').on('click', openNewOrderModal);

    // Function to close the modal
    function closeModal() {
        $('#newOrderCustomModal').hide();
    }

    // Attach the closeModal function to the close button
    $('.close-modal').on('click', closeModal);
});
$(document).ready(function () {
    console.log("Document is ready");
    $('.select2_1').select2({
        placeholder: "Select an option",
        allowClear: true
    });

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
            url: '@Url.Action("GetPrices", "CheckCustmer")',
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
var loadFile = function (event) {
    var image = document.getElementById('output');
    image.src = URL.createObjectURL(event.target.files[0]);
};
// ==================== My Check Customer ====================

// ==================== City Delivery ====================
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

// ==================== Customer Message ====================
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
// ==================== Customer Message ====================

// ==================== FAQ Descriptions ====================
$(document).ready(function () {
    // Bind change event to the selected company
    $('#SelectFAQ').change(function () {
        console.log("Selected FAQ changed");
        updateCosting();
    });
});
// ==================== FAQ Descriptions ====================

// ==================== Information Companies ====================
$(document).ready(function () {
    $('.select2_1').select2({
        placeholder: "Select an option",
        allowClear: true
    });

    $('#merchant-select').change(function () {
        var userId = $(this).val();
        if (userId) {
            $.getJSON('@Url.Action("GetUserDetails", "InformationCompanies")', { id: userId }, function (data) {
                $('input[name="InformationCompanies.CompanyName"]').val(data.companyName);
                $('input[name="InformationCompanies.PhoneCompany"]').val(data.phoneCompany);
                $('input[name="InformationCompanies.PhoneCompanySecand"]').val(data.phoneCompanySecand);
                $('input[name="InformationCompanies.EmailCompany"]').val(data.emailCompany);

            });
        }
    });
});
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
// ==================== Information Companies ====================

// ==================== Order New ====================
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
// ==================== Order New ====================