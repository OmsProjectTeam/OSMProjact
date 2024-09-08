$(document).ready(function () {
    $("#url").val(window.location.href);
    // Initialize select2 for dropdowns
    $('.select2_1').select2({
        placeholder: "Select an option",
        allowClear: true
    });

    // Bind change events to the company and currency selects, and weight input
    $('#selectedcompany, #toCurrency, #weight').on('change input', function () {
        updateCosting();
    });

    // Function to update costing based on selected inputs
    function updateCosting() {
        const selectedCompany = $('#selectedcompany').val();
        const weight = parseFloat($('#weight').val());
        const toCurrency = $('#toCurrency').val();

        if (isNaN(weight) || weight <= 0) {
            console.log("Invalid weight value");
            clearCostingFields();
            return;
        }

        console.log("Selected company is: ", selectedCompany);
        console.log("Weight is: ", weight);
        console.log("Currency is: ", toCurrency);

        $.ajax({
            url: getPricesUrl,
            data: {
                selectedCompanyId: selectedCompany,
                weight: weight,
                toCurrencyId: toCurrency,
                fromCurrencyId: 1
            },
            success: function (data) {
                if (data) {
                    $('#costPrice').val(data.costPrice);
                    $('#price').val(data.price);
                    $('#exchangePrice').val(data.exchangePrice);
                } else {
                    clearCostingFields();
                }
            },
            error: function () {
                alert('Error! Please try again.');
            }
        });
    }

    // Function to clear costing fields
    function clearCostingFields() {
        $('#costPrice').val('');
        $('#price').val('');
        $('#exchangePrice').val('');
    }

    // File input preview function
    var loadFile = function (event) {
        var image = document.getElementById('output');
        image.src = URL.createObjectURL(event.target.files[0]);
    };

    // Assign the file input function to the window scope
    window.loadFile = loadFile;
});
