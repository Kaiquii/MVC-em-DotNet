$(function () {
    var storageKey = "cadastro-theme";
    var $toggle = $("#themeToggle");
    var $text = $toggle.find(".theme-toggle-text");

    function applyTheme(theme) {
        var isDark = theme === "dark";
        document.documentElement.setAttribute("data-theme", theme);
        localStorage.setItem(storageKey, theme);
        $text.text(isDark ? "Escuro" : "Claro");
    }

    applyTheme(localStorage.getItem(storageKey) || "light");

    $toggle.on("click", function () {
        var currentTheme = document.documentElement.getAttribute("data-theme") || "light";
        applyTheme(currentTheme === "dark" ? "light" : "dark");
    });
});
