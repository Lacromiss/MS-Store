$(document).ready(function() {
    // Formun submit olayına event listener ekle
    $('#filter-form').submit(function(event) {
        // Olayın default davranışını iptal et
        event.preventDefault();

        // Filtreleme parametrelerini al
        var minPrice = $('#min-price').val();
        var maxPrice = $('#max-price').val();
        var colors = $('#colors').val();

        // AJAX isteği gönder
        $.ajax({
            url: '/Product/Filter',
            type: 'POST',
            data: {
                minPrice: minPrice,
                maxPrice: maxPrice,
                colors: colors
            },
            success: function(filteredProducts) {
                // Filtrelenen ürünleri işle
                displayFilteredProducts(filteredProducts);
            },
            error: function(xhr, status, error) {
                // Hata durumunda işlem yap
                console.error(error);
            }
        });
    });
});

// Filtrelenen ürünleri göster
function displayFilteredProducts(filteredProducts) {
    // Önceki ürünleri temizle
    $('#filtered-products').empty();

    // Filtrelenen ürünleri döngü ile işle
    filteredProducts.forEach(function(product) {
        $('#filtered-products').append(
            '<div class="product-item">' +
                '<h3>' + product.Name + '</h3>' +
                '<p>' + product.Description + '</p>' +
                '<img src="' + product.ImgUrl + '" alt="' + product.Name + '" />' +
                '<p>Fiyat: ' + product.Price + ' TL</p>' +
            '</div>'
        );
    });
}
