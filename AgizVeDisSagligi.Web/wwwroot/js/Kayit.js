document.getElementById("registrationForm").addEventListener("submit", function (event) {
    // Get the email and password field values
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var name = document.getElementById("name").value;
    var surname = document.getElementById("surname").value;
    var birthdate = document.getElementById("birthdate").value;
    var errorMessage = document.getElementById("errorMessage");

    // Clear previous error message
    errorMessage.textContent = "";

    // Email Validation
    if (email === "") {
        errorMessage.textContent = "Email cannot be empty!";
        event.preventDefault();
        return;
    }

    if (email.length < 10) {
        errorMessage.textContent = "Email must be at least 10 characters long!";
        event.preventDefault();
        return;
    }

    if (!email.includes("@hotmail") && !email.includes("@gmail")) {
        errorMessage.textContent = "Email must be from either @hotmail or @gmail!";
        event.preventDefault();
        return;
    }


    // Password Validation
    
    if (password.length < 8) {
        errorMessage.textContent = "Password must be at least 8 characters long!";
        event.preventDefault();
        return;
    }

    if (!/[A-Z]/.test(password)) {
        errorMessage.textContent = "Password must contain at least one uppercase letter!";
        event.preventDefault();
        return;
    }

    if (!/[a-z]/.test(password)) {
        errorMessage.textContent = "Password must contain at least one lowercase letter!";
        event.preventDefault();
        return;
    }

    if (!/[0-9]/.test(password)) {
        errorMessage.textContent = "Password must contain at least one number!";
        event.preventDefault();
        return;
    }
    if (name == "") {
        errorMessage.textContent = "isim alanı boş olamaz";
        event.preventDefault();
        return;
    }
    if (surname == "") {
        errorMessage.textContent = "isim alanı boş olamaz";
        event.preventDefault();
        return;
    }
    if (surname == "") {
        errorMessage.textContent = "dogum tarihinizi giriniz";
        event.preventDefault();
        return;
    }


});
