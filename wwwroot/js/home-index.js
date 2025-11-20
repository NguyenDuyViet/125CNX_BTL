// Home Index Page Scripts

// Countdown Timer
function updateCountdown() {
    const countdownElements = document.querySelectorAll('.countdown-item');
    if (countdownElements.length === 3) {
        let hours = parseInt(countdownElements[0].querySelector('.fw-bold').textContent);
        let minutes = parseInt(countdownElements[1].querySelector('.fw-bold').textContent);
        let seconds = parseInt(countdownElements[2].querySelector('.fw-bold').textContent);

        setInterval(() => {
            seconds--;
            if (seconds < 0) {
                seconds = 59;
                minutes--;
            }
            if (minutes < 0) {
                minutes = 59;
                hours--;
            }
            if (hours < 0) {
                hours = 23;
                minutes = 59;
                seconds = 59;
            }

            countdownElements[0].querySelector('.fw-bold').textContent = hours.toString().padStart(2, '0');
            countdownElements[1].querySelector('.fw-bold').textContent = minutes.toString().padStart(2, '0');
            countdownElements[2].querySelector('.fw-bold').textContent = seconds.toString().padStart(2, '0');
        }, 1000);
    }
}

// Add to cart notification
document.addEventListener('DOMContentLoaded', function() {
    updateCountdown();

    const addToCartButtons = document.querySelectorAll('.btn-primary');
    addToCartButtons.forEach(button => {
        if (button.textContent.includes('Thêm vào giỏ')) {
            button.addEventListener('click', function(e) {
                e.preventDefault();
                
                // Add animation
                this.innerHTML = '<i class="bi bi-check-circle me-2"></i>Đã thêm!';
                this.classList.remove('btn-primary');
                this.classList.add('btn-success');
                
                setTimeout(() => {
                    this.innerHTML = '<i class="bi bi-cart-plus me-2"></i>Thêm vào giỏ';
                    this.classList.remove('btn-success');
                    this.classList.add('btn-primary');
                }, 2000);
            });
        }
    });

    // Wishlist buttons
    const wishlistButtons = document.querySelectorAll('.product-overlay .btn');
    wishlistButtons.forEach(button => {
        if (button.querySelector('.bi-heart')) {
            button.addEventListener('click', function(e) {
                e.preventDefault();
                const icon = this.querySelector('i');
                if (icon.classList.contains('bi-heart')) {
                    icon.classList.remove('bi-heart');
                    icon.classList.add('bi-heart-fill');
                    this.classList.add('text-danger');
                } else {
                    icon.classList.remove('bi-heart-fill');
                    icon.classList.add('bi-heart');
                    this.classList.remove('text-danger');
                }
            });
        }
    });
});

// Newsletter form
document.querySelector('.newsletter-form')?.addEventListener('submit', function(e) {
    e.preventDefault();
    const email = this.querySelector('input[type="email"]').value;
    alert('Cảm ơn bạn đã đăng ký! Mã giảm giá đã được gửi đến: ' + email);
    this.reset();
});

// Lazy loading images
if ('IntersectionObserver' in window) {
    const imageObserver = new IntersectionObserver((entries, observer) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const img = entry.target;
                img.src = img.dataset.src || img.src;
                img.classList.add('loaded');
                observer.unobserve(img);
            }
        });
    });

    document.querySelectorAll('img').forEach(img => imageObserver.observe(img));
}
