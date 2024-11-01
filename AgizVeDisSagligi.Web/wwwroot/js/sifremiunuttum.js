
    function validatePassword(event) {
        const password = document.getElementById('password').value;
    const errorMessage = document.getElementById('error-message');

    // Hata mesajını temizle
    errorMessage.textContent = "";

    // Şifre kuralları
    if (password.length < 8) {
        errorMessage.textContent = "Şifre en az 8 karakter uzunluğunda olmalıdır!";
    event.preventDefault();
    return false;
        }

    if (!/[A-Z]/.test(password)) {
        errorMessage.textContent = "Şifre en az bir büyük harf içermelidir!";
    event.preventDefault();
    return false;
        }

    if (!/[a-z]/.test(password)) {
        errorMessage.textContent = "Şifre en az bir küçük harf içermelidir!";
    event.preventDefault();
    return false;
        }

    if (!/[0-9]/.test(password)) {
        errorMessage.textContent = "Şifre en az bir rakam içermelidir!";
    event.preventDefault();
    return false;
        }

    return true; // Tüm kurallar geçildiyse form gönderilir
    }
