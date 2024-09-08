
$(document).ready(function () {
  
        // Array of table IDs to initialize DataTables on
        var tableIds = ["example", "example1", "example2", "example3", "example4", "example5", "example6", "example7", "example8", "example9"];

        // Loop through each table ID and initialize DataTable
        $.each(tableIds, function (index, tableId) {
            // Destroy any existing DataTable instance on this table
            $("#" + tableId).DataTable().fnDestroy();

            // Initialize DataTable with options
            $('#' + tableId).DataTable({
                "paging": false,
                "lengthChange": false,
                "searching": false,
                "ordering": true,
                "info": true,
                "autoWidth": false
            });
        });
    }
    
    // Initialize Select2
    $('.select2_1').select2({
        placeholder: "Select an option",
        allowClear: true
    });

    // Merchant select change event
    $('#merchant-select').change(function () {
        var userId = $(this).val();
        if (userId) {
            $.getJSON(getUserDetailsUrl, { id: userId }, function (data) {
                $('input[name="ShippingAddresseClint.CompanyName"]').val(data.companyName);
                $('input[name="ShippingAddresseClint.PhoneCompany"]').val(data.phoneCompany);
                $('input[name="ShippingAddresseClint.PhoneCompanySecand"]').val(data.phoneCompanySecand);
                $('input[name="ShippingAddresseClint.EmailCompany"]').val(data.emailCompany);
            });
        }
    });

    // Load file preview for image input
    var loadFile = function (event) {
        var image = document.getElementById('output');
        image.src = URL.createObjectURL(event.target.files[0]);
    };

    // Set current URL in hidden input
    $("#url").val(window.location.href);

    // City select change event to populate areas
    $('#city-select').change(function () {
        var cityId = $(this).val();
        if (cityId) {
            $.getJSON(getAreasByCityUrl, { cityId: cityId }, function (data) {
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

    // Nike name select change event to update prices
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

    // Delivery tariff select change event to update delivery prices
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

    // Function to update delivery price Clint based on selections
    function updateDeliveryPriceClint() {
        $('#delivery-price-clint').val(''); // Clear existing value

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

    // Attach change and input events for updateDeliveryPriceClint
    $('#clintName, #city-select, #area-select, #nike-name-select, #type-system-select').change(updateDeliveryPriceClint);
    $('#description, #landmark, #price-under-10, #price-above-10, #local-delivery-description, #dealingStatus, #deliveryCustomer, #exchangePrice').on('input', updateDeliveryPriceClint);
});
