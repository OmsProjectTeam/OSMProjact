$(document).ready(function () {
    // Form submission for phone number search
    $('#phoneSearchForm').on('submit', function (e) {
        e.preventDefault(); // Prevent default form submission

        var phoneNumber = $('#phoneNo').val(); // Getting the phone number input value

        $.ajax({
            url: gitPhoneNumberUrl,  // Use the global variable defined in the Razor view
            type: 'POST',
            data: { PhoneNumber: phoneNumber },
            success: function (response) {
                console.log('Response Received:', response);

                if (response && response.success) {
                    // Populate the client details
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

                    // Show success message and update client dropdown
                    if (response.message) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Success',
                            text: response.message,
                            showConfirmButton: false,
                            timer: 2000
                        }).then(() => {
                            $('#clintName').append(new Option(response.name, response.userId, true, true));
                            setTimeout(() => {
                                $('#customModal').show();
                            }, 500);
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
                            $('#customModal').show();
                        }
                    });
                }
            },
            error: function () {
                $('#errorMessage').text('An error occurred while processing your request.');
            }
        });
    });

    // Close modal function
    function closeModal() {
        $('#customModal').hide();
    }

    // Event listener to close modal when clicking on the close button
    $('.close-modal').on('click', closeModal);

    // Open modal on "Add New Address" button click
    $('#addNewAddressButton').on('click', function () {
        $('#customModal').show();
    });

    // City select change event
    $('#city-select').change(function () {
        var cityId = $(this).val();
        if (cityId) {
            $.getJSON(getAreasByCityUrl, { cityId: cityId }, function (data) {
                var $areaSelect = $('#area-select');
                $areaSelect.empty(); // Clear the existing options
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

    // Nike name select change event
    $('#nike-name-select').change(function () {
        var shippingPriceId = $(this).val();
        if (shippingPriceId) {
            $.getJSON(getShippingPricesByNikeNameUrl, { shippingPriceId: shippingPriceId }, function (data) {
                if (data) {
                    $('#price-under-10').val(data.coPricePerkgUnder10);
                    $('#price-above-10').val(data.coPricePerkgAbove10);
                }
            }).fail(function (jqxhr, textStatus, error) {
                console.error('Request Failed:', textStatus, error);
            });
        }
    });

    // Delivery tariff select change event
    $('#delivery-tarrif-select').change(function () {
        var typeSystemId = $(this).val();
        if (typeSystemId) {
            $.getJSON(getDeliveryDetailsByTypeSystemUrl, { typeSystemId: typeSystemId }, function (data) {
                if (data) {
                    $('#delivery-company').val(data.companyPricing);
                    $('#delivery-client').val(data.deliveryPriceClint);
                }
            }).fail(function (jqxhr, textStatus, error) {
                console.error('Request Failed:', textStatus, error);
            });
        }
    });

    // Update Delivery Price Clint
    function updateDeliveryPriceClint() {
        var clintName = $('#clintName option:selected').text() || 'N/A';
        var city = $('#city-select option:selected').text() || 'N/A';
        var area = $('#area-select option:selected').text() || 'N/A';
        var landmark = $('#landmark').val() || 'N/A';
        var nikeName = $('#nike-name-select option:selected').text() || 'N/A';
        var under10 = $('#shipping-under-10').val() || 'N/A';
        var above10 = $('#shipping-above-10').val() || 'N/A';
        var system = $('#type-system-select option:selected').text() || 'N/A';
        var dealingStatus = $('#dealing-status').val() || 'N/A';
        var deliveryCustomer = $('#delivery-customer').val() || 'N/A';
        var exchangePrice = $('#type-system-select option:selected').val() || 'N/A';

        var combined = `Clint Name: ${clintName} -- City Name: ${city} -- Area Name: ${area} -- Landmark: ${landmark} -- Customer shipping price is less than 10: ${under10} -- Customer shipping price is more than 10: ${above10} -- Nick name: ${nikeName} -- System: ${system} -- Delivery price to the customer: ${deliveryCustomer} -- exchange: ${exchangePrice} -- Dealing status: ${dealingStatus}`;
        $('#delivery-price-clint').val(combined);
    }
    $('#clintName, #city-select, #area-select, #nike-name-select, #type-system-select').change(updateDeliveryPriceClint);
    $('#description, #landmark, #price-under-10, #price-above-10, #local-delivery-description, #dealingStatus, #deliveryCustomer, #exchangePrice').on('input', updateDeliveryPriceClint);

    // Open the New Order Modal
    function openNewOrderModal() {
        $('#newOrderCustomModal').show();
    }
    $('#addNewOrderButton').on('click', openNewOrderModal);
    $('.close-modal').on('click', closeModal);

    // File input preview
    var loadFile = function (event) {
        var image = document.getElementById('output');
        image.src = URL.createObjectURL(event.target.files[0]);
    };

    // Set the current URL
    $("#url").val(window.location.href);
});
