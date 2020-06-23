var Locazioni = [];
function LoadLocazione(element) {
    if (Locazioni.length == 0) {
        $.ajax({
            type: "GET",
            url: '/home/getLocazioneArea',
            success: function (data) {

            }
        })
    }
}
