$(document).ready(function () {
   
    $("#goste2").click(function () {
        $("#secilenlistele").click(function () {
       
            var favorite = [];

            var sayac = 0;

            $.each($("input[name='ogrencid']:checked"), function () {

                sayac = sayac + 1;
                if (sayac <= 5) {
                    favorite.push($(this).data("id"));

                }
            });
            if ((sayac <= 2 && sayac > 0) ) {

                   
               
                sayac = 0;
                $("#exampleModal2").dialog({
                    closeOnEscape: true,
                    draggable: false,
                    resizable: false,
                    modal: true,

                });
                window.location.replace("/Anasayfa/ikikisilik?veril=" + favorite.join(","));
                   
                  
            }
            else {
                sayac = 0;
                $("#modalConfirmDelete").dialog({
                    closeOnEscape: false,
                    draggable: false,
                    resizable: false,
                    modal: true,

                });


            }
        });
    });
    $("#goste5").click(function () {
        $("#secilenlistele").click(function () {
            var favorite = [];

            var sayac = 0;

            $.each($("input[name='ogrencid']:checked"), function () {

                sayac = sayac + 1;
                if (sayac <= 5) {
                    favorite.push($(this).data("id"));

                }
            });
            if (sayac <= 5 && sayac > 0) {
               

                sayac = 0;
                $("#exampleModal2").dialog({
                    closeOnEscape: true,
                    draggable: false,
                    resizable: false,
                    modal: true,

                });
                window.location.replace("/Anasayfa/beskisilik?veril=" + favorite.join(","));
            }
            else {

                sayac = 0;
                $("#modalConfirmDelete").dialog({
                    closeOnEscape: false,
                    draggable: false,
                    resizable: false,
                    modal: true,

                });

            }
        });
    });
    $("#goste4kis").click(function () {
        $("#secilenlistele").click(function () {
            var favorite = [];
            
            var sayac = 0;

            $.each($("input[name='ogrencid']:checked"), function () {

                sayac = sayac + 1;
                if (sayac <= 4) {
                    favorite.push($(this).data("id"));

                }
            });
            if (sayac <= 4 && sayac > 0) {
              
                sayac = 0;
                $("#exampleModal2").dialog({
                    closeOnEscape: true,
                    draggable: false,
                    resizable: false,
                    modal: true,

                });
                window.location.replace("/Anasayfa/dortkisibanyolu?veril=" + favorite.join(","));
            }
            else {
                sayac = 0;
                $("#modalConfirmDelete").dialog({
                    closeOnEscape: false,
                    draggable: false,
                    resizable: false,
                    modal: true,

                });

            }
        });
    });
    $("#goste4kisi").click(function () {
        $("#secilenlistele").click(function () {
            var favorite = [];
            var sayac = 0;

            $.each($("input[name='ogrencid']:checked"), function () {

                sayac = sayac + 1;
                if (sayac <= 4) {
                    favorite.push($(this).data("id"));

                }
            });
            if (sayac <= 4 && sayac > 0) {
               
                sayac = 0;
                $("#exampleModal2").dialog({
                    closeOnEscape: true,
                    draggable: false,
                    resizable: false,
                    modal: true,

                });
                window.location.replace("/Anasayfa/dortkisibanyosuz?veril=" + favorite.join(","));
            }
            else {
                sayac = 0;
                $("#modalConfirmDelete").dialog({
                    closeOnEscape: false,
                    draggable: false,
                    resizable: false,
                    modal: true,

                });

            }
        });
    });
});