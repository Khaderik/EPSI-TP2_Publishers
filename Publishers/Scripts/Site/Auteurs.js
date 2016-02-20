// Fonction de gestion de la pagination
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


// Fonction de suppression d'un auteur (AJAX)
$(function () {
    function RemoveClick() {
        // Get the id from the link
        var tr = $(this).parent().parent();
        var nom = tr.find("#nomAut").html();
        var idToDelete = tr.attr("id");

        if (idToDelete != '' && confirm('Voulez-vous supprimer l\'auteur:' + nom +  ' de votre panier ? ')) {
            // Perform the ajax post
            $.post("/authors/SupprAuteur", { "id": idToDelete },
            function (data) {
                // Successful requests get here
                // Update the page elements
                if (data.DeleteId != "0") {
                    $('#' + data.DeleteId).fadeOut('slow');
                }
                $('#update-message').text(data.Message);
                $('#update-message').show('slow', null).delay(3000).hide('slow');
            });
        }
    };

    // Document.ready -> link up remove event handler
    $('a[name=supprAuteur]').bind('click', RemoveClick);
});



