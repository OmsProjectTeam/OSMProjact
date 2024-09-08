$(document).ready(function () {
    $('#orderId').change(function () {
        updateCosting(false);
    });

    $('#toCurrency').change(function () {
        updateCosting(false);
    });

    $('#revisedMoney').on('input', function () {
        updateCosting(true);
    });

    function updateCosting(isManual) {
        const orderId = $('#orderId').val();
        const revisedMoney = $('#revisedMoney').val();
        const toCurrency = $('#toCurrency').val();

        $.ajax({
            url: getOrderDetailsUrl,
            data: {
                toCurrencyId: toCurrency,
                fromCurrencyId: 1,
                revisedMoney: revisedMoney,
                orderId: orderId,
                isManual: isManual
            },
            success: function (data) {
                if (data) {
                    $('#exchangePrice').val(data.exchangedPrice);
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
            }
        });
    }

    var loadFile = function (event) {
        var image = document.getElementById('output');
        image.src = URL.createObjectURL(event.target.files[0]);
    };
});
