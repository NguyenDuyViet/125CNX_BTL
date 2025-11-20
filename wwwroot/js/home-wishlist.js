// Wishlist Page Scripts

function removeFromWishlist(id) {
    if (confirm('Bạn có chắc muốn xóa sản phẩm này khỏi danh sách yêu thích?')) {
        // Add your remove logic here
        console.log('Removed item:', id);
    }
}

function clearWishlist() {
    if (confirm('Bạn có chắc muốn xóa tất cả sản phẩm trong danh sách yêu thích?')) {
        // Add your clear logic here
        document.getElementById('emptyWishlist').classList.remove('d-none');
    }
}

function addToWishlist() {
    alert('Đã thêm vào danh sách yêu thích!');
}
