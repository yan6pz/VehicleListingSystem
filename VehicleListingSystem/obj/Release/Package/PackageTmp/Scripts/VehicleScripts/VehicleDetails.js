function VehicleDetails() {
    VehicleDetails.templateDialog = "<div><h2>{Manufacturer}</h2><hr/><br/>" +
        "<span class='details-container'>Model:<h3 class='details'>{Model}</h3></span><br/>" +
        "<span class='details-container'>Price:<h3 class='details'>{Price}</h3></span></div>";

    VehicleDetails.initialize = function() {
        VehicleDetails.sliderInitialization();
        VehicleDetails.startUp();
        VehicleDetails.populateModels();
        VehicleDetails.FilterHandler();
    };

    VehicleDetails.sliderInitialization = function() {
        $("#slider-range").slider({
            range: true,
            min: 0,
            max: 100000,
            slide: function(event, ui) {
                $("#amount").val(ui.values[0] + "-" + ui.values[1]);
            }
        });
        $("#amount").val($("#slider-range").slider("values", 0) + $("#slider-range").slider("values", 1));
    };

    VehicleDetails.FilterHandler = function() {
        $("#filter-criteria").on("click", function() {

            var manufacturer = $('#manufacturer').val().replace(/ /g, '');
            var model;
            if (VehicleDetails.hasValue($('#model-options-select').val())) {
                model = $('#model-options-select').val().replace(/ /g, '');
            }
            var priceRange = $("#amount").val().split('-');
            
            if(VehicleDetails.hasValue(manufacturer))
                VehicleDetails.filterByManufacturer(manufacturer);
            if (VehicleDetails.hasValue(model))
                VehicleDetails.filterByModel(model);
            if (VehicleDetails.hasValue(priceRange))
                VehicleDetails.filterByPrice(priceRange);
        });
    };

    VehicleDetails.filterByManufacturer = function (manufacturer) {

        $("tr").show();
        if (manufacturer == "AllManufacturers")
            return;
        $("tr:not(." + manufacturer + "):not(.head-row)").hide();
    };

    VehicleDetails.filterByModel = function (model) {
        if (model == "ALL")
            return;
        $("tr").show();
        $("tr:not(." + model + "):not(.head-row)").hide();
    };

    VehicleDetails.filterByPrice = function(priceRange) {
        if ( priceRange.length!=2)
            return;
        var tableRows = document.getElementsByTagName("tr");
        for (var i = 0; i < tableRows.length; i++) {
            if (VehicleDetails.hasValue(tableRows[i].id) &&
                parseFloat(priceRange[0]) > parseFloat(tableRows[i].id) ||
                parseFloat(priceRange[1]) < parseFloat(tableRows[i].id)) {
                var id = tableRows[i].id.replace(".", "\\.");
                $('#' +id + '').hide();
                
            }
        }

    };

    VehicleDetails.hasValue = function(argument) {
        var hasValue = typeof (argument) != "undefined" && argument != null && argument != "";
        return hasValue;
    };

VehicleDetails.startUp = function () {
        $('.vehicle-name').on('click', function() {
            var id = this.id;
            $.ajax({
                url: "/Vehicle/Details",
                type: "POST",
                data: { id: id },
                success: function(data) {
                    VehicleDetails.showDialogDetails(data);
                },
                error: function() {
                    VehicleDetails.showDialogError();

                }
            });
        });
    };
    VehicleDetails.populateModels = function () {
        $('#manufacturer').on('change', function () {
            var manufacturer = this.value;
            $.ajax({
                url: "/Vehicle/GetModels",
                type: "POST",
                data: { manufacturer: manufacturer },
                success: function (data) {
                    VehicleDetails.showModels(data);
                },
                error: function () {
                    VehicleDetails.showDialogError();

                }
            });
        });
    };

    VehicleDetails.showModels = function (data) {
        
        var modelDiv = document.getElementById("model-options");
        modelDiv.innerHTML = "";
        var selectList = document.createElement("select");
        selectList.id = "model-options-select";
        modelDiv.appendChild(selectList);
        var optionAll = document.createElement("option");
        optionAll.value = "ALL";
        optionAll.text = "ALL";
        selectList.appendChild(optionAll);
        
        //Create and append the options
        for (var i = 0; i < data.length; i++) {
            var option = document.createElement("option");
            option.value = data[i].Model;
            option.text = data[i].Model;
            selectList.appendChild(option);
        }
    };
    
    VehicleDetails.showDialogDetails = function(data) {
        var manufacturer = data.Manufacturer;
        var model = data.Model;
        var price = data.Price;
        var currency = data.Currency;
        var actualPrice = price + " " + currency;
        var html = VehicleDetails.templateDialog.replace("{Manufacturer}", manufacturer)
            .replace("{Model}", model)
            .replace("{Price}", actualPrice);

        $("#create-confirmation")[0].innerHTML=html;
        $("#create-confirmation").dialog({
            title: "Details",
            resizable: true,
            height: 400,
            width:380,
            modal: true,
            buttons: [
                {
                    text: 'OK',
                    click: function() {
                        $(this).dialog("close");
                    }
                },
                {
                    text: 'Cancel',
                    click: function() {
                        $(this).dialog("close");
                    }
                }
            ]
        });
    };

    VehicleDetails.showDialogError = function() {
        $("#create-confirmation").text('Грешка! Опитайте по-късно.');
        $("#create-confirmation").dialog({
            title: "Error",
            resizable: true,
            height: 300,
            modal: true,
            buttons: [
                {
                    text: 'OK',
                    click: function() {
                        $(this).dialog("close");
                    }
                }
            ]
        });
    };


};