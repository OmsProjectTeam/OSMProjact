$(document).ready(function () {
    // Function to update the exchange rate based on selected currencies
    function updateExchangeRate() {
        // Get the selected values from the currency dropdowns
        const fromCurrency = $('#fromCurrency').val();
        const toCurrency = $('#toCurrency').val();

        // Make an AJAX request to get the exchange rate for the selected currencies
        $.ajax({
            // URL for the GetExchangeRate action in the Transaction controller
            url: getExchangeRateUrl,
            // Data to be sent to the server (selected currencies)
            data: { fromCurrencyId: fromCurrency, toCurrencyId: toCurrency },
            // Function to handle success response
            success: function (rate) {
                // Update the exchange rate input field with the fetched rate
                $('#exchangeRate').val(rate);
                // Calculate the converted amount based on the fetched exchange rate
                calculateConvertedAmount();

                // Calculate and display the reverse exchange rate
                const reverseRate = 1 / rate;
                $('#reverseExchangeRate').val(reverseRate.toFixed(6));
            },
            error: function () {
                $('#exchangeRate').val('N/A');
                $('#reverseExchangeRate').val('N/A');
            }
        });
    }

    // Function to calculate the converted amount based on the entered amount and exchange rate
    function calculateConvertedAmount() {
        // Get the values from the amount and exchange rate input fields
        const amount = parseFloat($('#amount').val());
        const rate = parseFloat($('#exchangeRate').val());

        // Check if the amount and rate are valid numbers
        if (!isNaN(amount) && !isNaN(rate)) {
            // Calculate the converted amount
            const convertedAmount = amount * rate;
            // Update the converted amount input field with the calculated value
            $('#convertedAmount').val(convertedAmount.toFixed(2));
        } else {
            $('#convertedAmount').val('');
        }
    }

    $('#fromCurrency, #toCurrency').change(function () {
        updateExchangeRate();
    });

    $('#amount').on('input', function () {
        calculateConvertedAmount();
    });

    // Initial call to update exchange rate
    updateExchangeRate();
});

// File input preview
var loadFile = function (event) {
    var image = document.getElementById('output');
    image.src = URL.createObjectURL(event.target.files[0]);
};
