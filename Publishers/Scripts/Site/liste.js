$(function () {
    $("#nomAuteur").change(function () {
        $("#PageCourante").val(1);
    });
    // Document.ready -> link up remove event handler
    $(".pagination a").click(function () {

        // Obtention du numéro de page
        var page = $(this).text();

        // Fixe la page courante dans le formulaire
        if (page == "»") {
            // Aller à la page suivante
            page = "" + (parseInt($("#PageCourante").val()) + 1);
        }
        else if (page == "»»") {
            // Aller à la dernière page
            page = "" + $("#PageCount").val();
        }
        else if (page == "«") {
            // Aller à la page précédente
            page = "" + (parseInt($("#PageCourante").val()) - 1);
        }
        else if (page == "««") {
            // Aller à la première page
            page = "1";
        }

        $("#PageCourante").val(page);
        // Déclenche le formulaire
        $("#formRecherche").submit();
    });
});
