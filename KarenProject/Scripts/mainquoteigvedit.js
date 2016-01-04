$(document).ready(function () {



    initHide();

    $('#level1label').text($('#FtoFStart1').val());
    $('#level2label').text($('#FtoFStart2').val());
    $('#level3label').text($('#FtoFStart3').val());
    $('#level4label').text($('#FtoFStart4').val());
    $('#level5label').text($('#FtoFStart5').val());

    hideSDH();

    setSection6();

    disableHandrailLoc();

    disableMirrorLoc();

    setEntrance();

    initsetup1();
    
    initialEventBinding();

    setLDFEmbDoorClose("1");
    setLDFEmbDoorClose("2");
    setLDFEmbDoorClose("3");
    setLDFEmbDoorClose("4");
    setLDFEmbDoorClose("5");
    setLDFEmbDoorClose("6");
    setLDFEmbDoorClose("7");
    setLDFEmbDoorClose("8");
    setLDFEmbDoorClose("9");
    setLDFEmbDoorClose("10");
    

    /*Row 226
    Added function calls to Toggle between door closer and opener
    */
    setLDFEmbDoorCloseToggle("1");
    setLDFEmbDoorCloseToggle("2");
    setLDFEmbDoorCloseToggle("3");
    setLDFEmbDoorCloseToggle("4");
    setLDFEmbDoorCloseToggle("5");
    setLDFEmbDoorCloseToggle("6");
    setLDFEmbDoorCloseToggle("7");
    setLDFEmbDoorCloseToggle("8");
    setLDFEmbDoorCloseToggle("9");
    setLDFEmbDoorCloseToggle("10");

    setWidthReadonly();
    getstructurefinish();
    setDoorHandel();
    floorsChange();
    part12ChangeOnLoad();
    setLadingDoor();
    changeNoOfLifts();
    disableCopLocOnLoad();
    Rule1();
    Rule3();
    Rule4();
    carHeightAlert();
    hideGSTPart18();
    LiftModelCapacityChange();
})

function initialEventBinding()
{
    $('#FtoFStart1').blur(function () {

        $('#FToF1').val($('#FtoFStart1').val());
        $('#FToF3').val($('#FtoFFinish1').val());

        $('#FToFD1').val($('#FtoFStart1').val());
        $('#FToFD3').val($('#FtoFFinish1').val());
        $('#level1label').text($('#FtoFStart1').val());
    });
    $('#FtoFFinish1').blur(function () {
        $('#FtoFStart2').val($('#FtoFFinish1').val());
        $('#level2label').text($('#FtoFStart2').val());
        $('#FToF1').val($('#FtoFStart1').val());
        $('#FToF3').val($('#FtoFFinish1').val());

        $('#FToFD1').val($('#FtoFStart1').val());
        $('#FToFD3').val($('#FtoFFinish1').val());


    });
    $('#FtoFStart2').blur(function () {

        $('#FtoFFinish1').val($('#FtoFStart2').val());
        $('#FToF3').val($('#FtoFFinish1').val());
        $('#FToF5').val($('#FtoFFinish2').val());

        $('#FToFD3').val($('#FtoFFinish1').val());
        $('#FToFD5').val($('#FtoFFinish2').val());
        $('#level2label').text($('#FtoFStart2').val());
    });
    $('#FtoFFinish2').blur(function () {
        $('#FtoFStart3').val($('#FtoFFinish2').val());
        $('#level3label').text($('#FtoFStart3').val());
        $('#FToF5').val($('#FtoFFinish2').val());


        $('#FToFD5').val($('#FtoFFinish2').val());

    });
    $('#FtoFStart3').blur(function () {
        $('#FtoFFinish2').val($('#FtoFStart3').val());

        $('#FToF7').val($('#FtoFFinish3').val());


        $('#FToFD7').val($('#FtoFFinish3').val());
        $('#level3label').text($('#FtoFStart3').val());
    });
    $('#FtoFFinish3').blur(function () {
        $('#FtoFStart4').val($('#FtoFFinish3').val());
        $('#level4label').text($('#FtoFStart4').val());
        $('#FToF7').val($('#FtoFFinish3').val());

        $('#FToFD7').val($('#FtoFFinish3').val());

    });
    $('#FtoFStart4').blur(function () {
        $('#FtoFFinish3').val($('#FtoFStart4').val());
        $('#FToF9').val($('#FtoFFinish4').val());


        $('#FToFD9').val($('#FtoFFinish4').val());
        $('#level4label').text($('#FtoFStart4').val());
    });
    $('#FtoFFinish4').blur(function () {
        $('#FToF9').val($('#FtoFFinish4').val());

        $('#FToFD9').val($('#FtoFFinish4').val());
        $('#level5label').text($('#FtoFFinish4').val());
    });


    $('#Part12').click(function () {
        part12Change();
        if ($('#Part12').is(":checked")) {
            if ($("#LiftType").val() == "Domus Evolution") {
                alert("You have selected Part 12, the following items are compulsory: CAR SIZE: 1100W x 1400D mm, DOOR SIZE: 900W mm, HANDRAIL: Rounded with curved ends, CAR OPERATING PANEL: x2 COP panels, Handsfree Phone, Full height light ray, Braille buttons, Car indicator.");
            }
            else {
                alert("You have selected Part 12, the following items are compulsory: CAR SIZE: 1100W x 1400D mm, DOOR SIZE: 900W mm, HANDRAIL: Rounded with curved ends, CAR OPERATING PANEL: x2 COP panels, Handsfree Phone, Full height light ray, Braille buttons.");

            }
        }
    })


    $('#power').change(function () {
        onPowerChange();
    });

    $('#codeComplence').change(function () {


        onPart12Change();
        changeCodeComplaince();
        LiftModelCapacityChange();
        hideGSTPart18();
    });

    $('#LiftType').change(function () {

        
        changeEntranceType();
        $.ajax({
            url: $("#getLiftModel").val(),
            type: 'POST',
            data: {
                Value: $(this).val(),
                Shaft: $("#LiftType").val(),
                Id: $("#entranceType").val(),
            },
            success: function (vv) {

                $("#liftModel").html('');
                $.each(vv, function (i, states) {
                    $("#liftModel").append('<option value="' + states.Value + '">' +
                         states.Text + '</option>');
                });
                $('#liftModel').val(vv[0].Value).trigger('change');
                if ($('#LiftType').val() == 'Domus Evolution') {
                    $("#CarDisplayType").val = "Icaro blue";
                }
                Rule1();
                Rule2();
                Rule3();
                Rule4();
                changeHeadRoom();
                
                if ($('#Part12').is(":checked")) {
                    $("#HandRailType").val("Round stainless steel with rounded corners");
                }
            },
            error: function (xhr) { alert("Something seems Wrong"); }
        });
        $.ajax({
            url: $("#getPower").val(),
            type: 'POST',
            data: {
                Value: $(this).val(),

                Id: $("#entranceType").val(),
            },
            success: function (vv) {

                $("#power").html('');
                $.each(vv, function (i, states) {
                    $("#power").append('<option value="' + states.Value + '">' +
                         states.Text + '</option>');
                    onPowerChange();
                    // here we are adding option for States

                });
            },
            error: function (xhr) { alert("Something seems Wrong"); }
        });

        LiftModelCapacityChange();

        $.ajax({
            url: $("#GetLDFDoorType").val(),
            type: 'POST',
            data: {
                Value: $(this).val(),

                Id: $("#entranceType").val(),
            },
            success: function (vv) {

                $("#LDFDoorType1").html('');
                $("#LDFDoorType2").html('');
                $("#LDFDoorType3").html('');
                $("#LDFDoorType4").html('');
                $("#LDFDoorType5").html('');
                $("#LDFDoorType6").html('');
                $("#LDFDoorType7").html('');
                $("#LDFDoorType8").html('');
                $("#LDFDoorType9").html('');
                $("#LDFDoorType10").html('');
                $.each(vv, function (i, states) {
                    $("#LDFDoorType1").append('<option value="' + states.Value + '">' +
                         states.Text + '</option>');
                    $("#LDFDoorType2").append('<option value="' + states.Value + '">' +
                        states.Text + '</option>');
                    $("#LDFDoorType3").append('<option value="' + states.Value + '">' +
                        states.Text + '</option>');
                    $("#LDFDoorType4").append('<option value="' + states.Value + '">' +
                        states.Text + '</option>');
                    $("#LDFDoorType5").append('<option value="' + states.Value + '">' +
                        states.Text + '</option>');
                    $("#LDFDoorType6").append('<option value="' + states.Value + '">' +
                        states.Text + '</option>');
                    $("#LDFDoorType7").append('<option value="' + states.Value + '">' +
                        states.Text + '</option>');
                    $("#LDFDoorType8").append('<option value="' + states.Value + '">' +
                        states.Text + '</option>');
                    $("#LDFDoorType9").append('<option value="' + states.Value + '">' +
                        states.Text + '</option>');
                    $("#LDFDoorType10").append('<option value="' + states.Value + '">' +
                        states.Text + '</option>');
                    // here we are adding option for StatesF
                    $('#LDFDoorType1').val(vv[0].Value).trigger('change');
                    $('#LDFDoorType2').val(vv[0].Value).trigger('change');
                    $('#LDFDoorType3').val(vv[0].Value).trigger('change');
                    $('#LDFDoorType4').val(vv[0].Value).trigger('change');
                    $('#LDFDoorType5').val(vv[0].Value).trigger('change');
                    $('#LDFDoorType6').val(vv[0].Value).trigger('change');
                    $('#LDFDoorType7').val(vv[0].Value).trigger('change');
                    $('#LDFDoorType8').val(vv[0].Value).trigger('change');
                    $('#LDFDoorType9').val(vv[0].Value).trigger('change');
                    $('#LDFDoorType10').val(vv[0].Value).trigger('change');
                });
            },
            error: function (xhr) { alert("Something seems Wrong"); }
        });

        $.ajax({
            url: $("#GetCarWalls").val(),
            type: 'POST',
            data: {
                Value: $(this).val(),

                Id: $("#entranceType").val(),
            },
            success: function (vv) {

                $("#CarWallsLHS").html('');
                $("#CarWallsRHS").html('');
                $("#CarWallsRear").html('');
                $.each(vv, function (i, states) {
                    $("#CarWallsLHS").append('<option value="' + states.Value + '">' +
                         states.Text + '</option>');
                    $("#CarWallsRHS").append('<option value="' + states.Value + '">' +
                         states.Text + '</option>');
                    $("#CarWallsRear").append('<option value="' + states.Value + '">' +
                         states.Text + '</option>');
                    // here we are adding option for States

                });
            },
            error: function (xhr) { alert("Something seems Wrong"); }
        });

        //  setSpeed();
        $.ajax({
            url: $("#GetDriveSystem").val(),
            type: 'POST',
            data: {
                Value: $(this).val(),

                Id: $("#entranceType").val(),
            },
            success: function (vv) {

                $("#driveSystem").html('');
                $.each(vv, function (i, states) {
                    $("#driveSystem").append('<option value="' + states.Value + '">' +
                         states.Text + '</option>');

                });
            },
            error: function (xhr) { alert("Something seems Wrong"); }
        });
        $("#CarHeight").html('');
        if ($("#LiftType").val() == "DomusXL" || $("#LiftType").val() == "DomusXL Spirit") {


            $("#CarHeight").append('<option value="2000">2000</option>');

            // here we are adding option for States


        }
        else {
            $("#CarHeight").append('<option value="2000">2000</option>');
            $("#CarHeight").append('<option value="1900">1900</option>');
            $("#CarHeight").append('<option value="1950">1950</option>');

            $("#CarHeight").append('<option value="2050">2050</option>');
            $("#CarHeight").append('<option value="2100">2100</option>');


        }
        $("#LopButton1").html('');
        $("#LopButton2").html('');
        $("#LopButton3").html('');
        $("#LopButton4").html('');
        $("#LopButton5").html('');
        $("#LopButton6").html('');
        $("#LopButton7").html('');
        $("#LopButton8").html('');
        $("#LopButton9").html('');
        $("#LopButton10").html('');

        if ($("#LiftType").val() == "Domus Spirit" || $("#LiftType").val() == "DomusXL Spirit") {
            $("#CarSafteyProtection").html('');
            $("#LopButton1").html('');
            $("#LopButton1").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton2").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton3").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton4").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton5").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton6").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton7").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton8").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton9").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton10").append('<option value="Silver Braille">Silver Braille<option>');
            $("#CarSafteyProtection").append('<option value="Photocell">Photocell<option>');
            $("#CarSafteyProtection").append('<option value="Full Height Safety edge">Full Height Safety edge</option>');


        }
        else {

            $("#LopButton1").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton1").append('<option value="Gold Braille">Gold Braille<option>');
            $("#LopButton1").append('<option value="Waterproof">Waterproof<option>');
            $("#LopButton2").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton2").append('<option value="Gold Braille">Gold Braille<option>');
            $("#LopButton2").append('<option value="Waterproof">Waterproof<option>');
            $("#LopButton3").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton3").append('<option value="Gold Braille">Gold Braille<option>');
            $("#LopButton3").append('<option value="Waterproof">Waterproof<option>');
            $("#LopButton4").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton4").append('<option value="Gold Braille">Gold Braille<option>');
            $("#LopButton4").append('<option value="Waterproof">Waterproof<option>');
            $("#LopButton5").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton5").append('<option value="Gold Braille">Gold Braille<option>');
            $("#LopButton5").append('<option value="Waterproof">Waterproof<option>');
            $("#LopButton6").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton6").append('<option value="Gold Braille">Gold Braille<option>');
            $("#LopButton6").append('<option value="Waterproof">Waterproof<option>');
            $("#LopButton7").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton7").append('<option value="Gold Braille">Gold Braille<option>');
            $("#LopButton7").append('<option value="Waterproof">Waterproof<option>');
            $("#LopButton8").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton8").append('<option value="Gold Braille">Gold Braille<option>');
            $("#LopButton8").append('<option value="Waterproof">Waterproof<option>');
            $("#LopButton9").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton9").append('<option value="Gold Braille">Gold Braille<option>');
            $("#LopButton9").append('<option value="Waterproof">Waterproof<option>');
            $("#LopButton10").append('<option value="Silver Braille">Silver Braille<option>');
            $("#LopButton10").append('<option value="Gold Braille">Gold Braille<option>');
            $("#LopButton10").append('<option value="Waterproof">Waterproof<option>');
            $("#CarSafteyProtection").html('');
            $("#CarSafteyProtection").append('<option value="Full Height Safety edge">Full Height Safety edge</option>');
        }

        if ($("#LiftType").val() == "DomusXL" || $("#LiftType").val() == "DomusXL Spirit" || $("#LiftType").val() == "Domus Evolution") {
            $("#conCabSize").val("720 mm W x 360 mm D x 1500 mm H");
        }
        else {
            $("#conCabSize").val("600mm W x  280mm D x 1000mm H");
        }


        setCladding();
        setLadingDoor();

        setDoorHandel();
        setWarranty();
        hideSDH();
    
        part12Change();
        if ($('#LiftType').val() == 'Domus Evolution') {
          
            $("#CarDisplayType").val("Icaro blue");
            $('#pit').val('150');
        }
    });

    $('#ShaftType').change(function () {
        setSection6();
        changeEntranceType();
        $('#entranceType').trigger('change');
        $.ajax({
            url: $("#GetDimensions").val(),
            type: 'POST',
            data: {
                Value: $("#LiftType").val(),

                Shaft: $("#ShaftType").val(),

                Model: $(this).val()
            },
            async: false,
            success: function (vv) {
                // alert(vv[0].Value);
                if (vv != null) {
                    $("#IntCarSizeWide").val(vv[0] == null ? 'custom...' : vv[0].Value);
                    $("#IntCarSizeDeep").val(vv[1] == null ? 'custom...' : vv[1].Value);
                    $("#ShaftSizeWide").val(vv[2] == null ? 'custom...' : vv[2].Value);
                    $("#ShaftSizeDeep").val(vv[3] == null ? 'custom...' : vv[3].Value);
                    $("#Door1SizeWide").val(vv[4] == null ? 'custom...' : vv[4].Value);
                    $("#Door2SizeWide").val(vv[6] == null ? 'custom...' : vv[6].Value);
                    $("#Door1SizeDeep").val($("#CarHeight").val());
                    if (vv[6] != null) {
                        if (vv[6].Value != "N/A") {
                            $("#Door2SizeDeep").val($("#CarHeight").val());
                        }
                    }

                    $("#Door2SizeDeep").val(vv[7] == null ? '' : vv[7].Value);
                }
                Rule3();
            },
            error: function (xhr) { alert("Something seems Wrong"); }
        });

    });

    $('#entranceType').change(function () {


        $.ajax({
            url: $("#getLiftModel").val(),
            type: 'POST',
            data: {
                Value: $("#LiftType").val(),

                Id: $(this).val(),
            },
            success: function (vv) {

                $("#liftModel").html('');
                $.each(vv, function (i, states) {
                    $("#liftModel").append('<option value="' + states.Value + '">' +
                         states.Text + '</option>');
                    // here we are adding option for States

                });
                //  $('#LiftType').val(vv[0].Value).trigger('change');
                $('#liftModel').val(vv[0].Value).trigger('change');
                Rule1();
                Rule2();
                Rule3();
                Rule4();
                Rule5();
            },
            error: function (xhr) { alert("Something seems Wrong"); }
        });




        setEntrance1();


        setEntrance();

    });

    $('#liftModel').change(function () {


        setWidthReadonly();
      //  changeEntranceType();
        $.ajax({
            url: $("#GetloadBearingWall").val(),
            type: 'POST',
            data: {
                Value: $(this).val(),

                Id: $("#entranceType").val(),
            },
            async: false,
            success: function (vv) {

                $("#loadBearingWall").html('');
                $.each(vv, function (i, states) {
                    $("#loadBearingWall").append('<option value="' + states.Value + '">' +
                         states.Text + '</option>');
                    // here we are adding option for States


                });
                $('#loadBearingWall').val(vv[0].Value).trigger('change');

            },
            error: function (xhr) { alert("Something seems Wrong"); }
        });

        $.ajax({
            url: $("#GetDimensions").val(),
            type: 'POST',
            data: {
                Value: $("#LiftType").val(),

                Shaft: $("#ShaftType").val(),

                Model: $(this).val()
            },
            async:false,
            success: function (vv) {
                // alert(vv[0].Value);
                if (vv != null) {
                    $("#IntCarSizeWide").val(vv[0] == null ? 'custom...' : vv[0].Value);
                    $("#IntCarSizeDeep").val(vv[1] == null ? 'custom...' : vv[1].Value);
                    $("#ShaftSizeWide").val(vv[2] == null ? 'custom...' : vv[2].Value);
                    $("#ShaftSizeDeep").val(vv[3] == null ? 'custom...' : vv[3].Value);
                    $("#Door1SizeWide").val(vv[4] == null ? 'custom...' : vv[4].Value);
                    $("#Door2SizeWide").val(vv[6] == null ? 'custom...' : vv[6].Value);
                    $("#Door1SizeDeep").val($("#CarHeight").val());
                    if (vv[6] != null) {
                        if (vv[6].Value != "N/A") {
                            $("#Door2SizeDeep").val($("#CarHeight").val());
                        }
                    }

                    $("#Door2SizeDeep").val(vv[7] == null ? '' : vv[7].Value);
                }
                Rule3();
            },
            error: function (xhr) { alert("Something seems Wrong"); }
        });

        Rule4();
        //aert("3");
        LiftModelCapacityChange();

    });

    $('#NoOfFloors').change(function () {

        floorsChange();
        checkAlllevel();
    });


    $('#SellingPrice').blur(function () {
        var gst = parseInt($("#SellingPrice").val());

        $('#Gst').val(gst / 10);
        if ($('#GstFree').is(":checked")) {
            $('#TotalSellingPrice').val(gst);

        }
        else {
            $('#TotalSellingPrice').val(gst + (gst / 10));
        }

    });

    $('#GstFree').click(function () {
        var gst = parseInt($("#SellingPrice").val());
        if ($('#GstFree').is(":checked")) {

            $('#Gst').val(0);
            $('#TotalSellingPrice').val(gst);

        }
        else {
            var gst = parseInt($("#SellingPrice").val());

            $('#Gst').val(gst / 10);
            if ($('#GstFree').is(":checked")) {
                $('#TotalSellingPrice').val(gst);

            }
            else {
                $('#TotalSellingPrice').val(gst + (gst / 10));
            }
        }
        changeNoOfLifts();
    });

    $('#HandRailType').change(disableHandrailLoc);

    $('#MirrorType').change(function () {
        disableMirrorLoc();
    });

    $('#CopLocDCOP').click(function () {
        if ($('#CopLocDCOP').is(":checked")) {
            $('#CopLocLHS').attr("disabled", false);
            $('#CopLocRHS').attr("disabled", false);
            $('#CopLocRear').attr("disabled", false);

        }
        else {
            //$('#CopLocLHS').attr("disabled", true);
            //$('#CopLocRHS').attr("disabled", true);
            //$('#CopLocRear').attr("disabled", true);

        }
    })

    $('#ShaftComRalPaint').click(function () {

        if ($('#ShaftComRalPaint').is(":checked")) {
            $('#SpecialRAL').show();
        }
        else {
            $('#SpecialRAL').hide();
        }
    })

    $('#Travel').change(function () {
        if ($('#codeComplence').val() == "Part 15") {
            if ($('#Travel').val() > 4000) {
                $('#Travel').val(4000);
            }

        }
        /*Row 213 
        Added block to limit travel to 12000 for part 18
        */
        if ($('#codeComplence').val() == "Part 18") {
            if ($('#Travel').val() > 12000) {
                $('#Travel').val(12000);
            }

        }

    });

    $('#CarHeight').change(function () {

        changeHeadRoom();
        $("#Door1SizeDeep").val($("#CarHeight").val());

        if ($("#Door2SizeDeep").val() != "N/A") {
            $("#Door2SizeDeep").val($("#CarHeight").val());
        }



    });

    $('#Profile').change(function () {

        if ($(this).val() == "RAL painted - Special colour") {
            $('#special').show();
        }
        else {
            $('#special').hide();
        }





    });

    $('#loadBearingWall').change(function () {

        setCOPLocation();
    });

    $('#CarWallsLHS').change(function () {

        $('#CarWallsRHS').val($(this).val());
        $('#CarWallsRear').val($(this).val());
    });


    $('#LopLocation1').change(LopLocationChange);
    $('#LopLocation2').change(LopLocationChange);
    $('#LopLocation3').change(LopLocationChange);
    $('#LopLocation4').change(LopLocationChange);
    $('#LopLocation5').change(LopLocationChange);
    $('#LopLocation6').change(LopLocationChange);
    $('#LopLocation7').change(LopLocationChange);
    $('#LopLocation8').change(LopLocationChange);
    $('#LopLocation9').change(LopLocationChange);
    $('#LopLocation10').change(LopLocationChange);

    $('#LDFDoorType1').change(changeLdfDoorType);
    $('#LDFDoorType2').change(changeLdfDoorType);
    $('#LDFDoorType3').change(changeLdfDoorType);
    $('#LDFDoorType4').change(changeLdfDoorType);
    $('#LDFDoorType5').change(changeLdfDoorType);
    $('#LDFDoorType6').change(changeLdfDoorType);
    $('#LDFDoorType7').change(changeLdfDoorType);
    $('#LDFDoorType8').change(changeLdfDoorType);
    $('#LDFDoorType9').change(changeLdfDoorType);
    $('#LDFDoorType10').change(changeLdfDoorType);

    $('#DoorEntType1').change(function () {

        if ($("#DoorEntType1").val() == "Front & Second entrance") {
            $('#DivDoorEntType2').show();
            $('#DivLDFDoorType2').show();
        }
        else {
            $('#DivDoorEntType2').hide();
            $('#DivLDFDoorType2').hide();
        }
    });
    $('#DoorEntType3').change(function () {

        if ($("#DoorEntType3").val() == "Front & Second entrance") {
            $('#DivDoorEntType4').show();
            $('#DivLDFDoorType4').show();
        }
        else {
            $('#DivDoorEntType4').hide();
            $('#DivLDFDoorType4').hide();
        }
    });
    $('#DoorEntType5').change(function () {

        if ($("#DoorEntType5").val() == "Front & Second entrance") {
            $('#DivDoorEntType6').show();
            $('#DivLDFDoorType6').show();
        }
        else {
            $('#DivDoorEntType6').hide();
            $('#DivLDFDoorType6').hide();
        }
    });
    $('#DoorEntType7').change(function () {

        if ($("#DoorEntType7").val() == "Front & Second entrance") {
            $('#DivDoorEntType8').show();
            $('#DivLDFDoorType8').show();
        }
        else {
            $('#DivDoorEntType8').hide();
            $('#DivLDFDoorType8').hide();
        }
    });
    $('#DoorEntType9').change(function () {

        if ($("#DoorEntType9").val() == "Front & Second entrance") {
            $('#DivDoorEntType10').show();
            $('#DivLDFDoorType10').show();

        }
        else {
            $('#DivDoorEntType10').hide();
            $('#DivLDFDoorType10').hide();
        }
    });


}

function setCarWallsDefault() {

    var delay = 1000;//1 seconds
    setTimeout(function () {
        $(CarWallsRHS).find('option').filter(function () {
            return this.text === 'Skinplate A32PP - Polished Effect';
        }).attr('selected', 'selected');
        $(CarWallsLHS).find('option').filter(function () {
            return this.text === 'Skinplate A32PP - Polished Effect';
        }).attr('selected', 'selected');
        $(CarWallsRear).find('option').filter(function () {
            return this.text === 'Skinplate A32PP - Polished Effect';
        }).attr('selected', 'selected');

        $(LDFDoorType1).find('option').filter(function () {
            return this.text === 'B - Panoramic aluminium with transparent glass';
        }).attr('selected', 'selected');
        $(LDFDoorType2).find('option').filter(function () {
            return this.text === 'B - Panoramic aluminium with transparent glass';
        }).attr('selected', 'selected');
        $(LDFDoorType3).find('option').filter(function () {
            return this.text === 'B - Panoramic aluminium with transparent glass';
        }).attr('selected', 'selected');
        $(LDFDoorType4).find('option').filter(function () {
            return this.text === 'B - Panoramic aluminium with transparent glass';
        }).attr('selected', 'selected');
        $(LDFDoorType5).find('option').filter(function () {
            return this.text === 'B - Panoramic aluminium with transparent glass';
        }).attr('selected', 'selected');
        $(LDFDoorType6).find('option').filter(function () {
            return this.text === 'B - Panoramic aluminium with transparent glass';
        }).attr('selected', 'selected');
        $(LDFDoorType7).find('option').filter(function () {
            return this.text === 'B - Panoramic aluminium with transparent glass';
        }).attr('selected', 'selected');
        $(LDFDoorType8).find('option').filter(function () {
            return this.text === 'B - Panoramic aluminium with transparent glass';
        }).attr('selected', 'selected');
        $(LDFDoorType9).find('option').filter(function () {
            return this.text === 'B - Panoramic aluminium with transparent glass';
        }).attr('selected', 'selected');
        $(LDFDoorType10).find('option').filter(function () {
            return this.text === 'B - Panoramic aluminium with transparent glass';
        }).attr('selected', 'selected');


        //your code to be executed after 1 seconds
    }, delay);



}

function setEntrance() {
 
    if ($("#entranceType").val() == "Front entrance") {
        $('#DiSecondEntLanDoor').hide();
        $('#DivDoor2').hide();
        $('#CarWallsLHS').show();
        $('#CarWallsRHS').show();
        $('#CarWallsRear').show();
        $('#CarWallsLHSLabel').show();
        $('#CarWallsRHSLabel').show();
        $('#CarWallsRearLabel').show();
    }
    else {
        if ($("#entranceType").val() == "Front & Rear entrance") {
            $('#CarWallsLHS').show();
            $('#CarWallsRHS').show();
            $('#CarWallsRear').hide();
            $('#CarWallsLHSLabel').show();
            $('#CarWallsRHSLabel').show();
            $('#CarWallsRearLabel').hide();
        }
        if ($("#entranceType").val() == "Front & Adjacent – Left") {
            $('#CarWallsLHS').hide();
            $('#CarWallsRHS').show();
            $('#CarWallsRear').show();
            $('#CarWallsLHSLabel').hide();
            $('#CarWallsRHSLabel').show();
            $('#CarWallsRearLabel').show();
        }
        if ($("#entranceType").val() == "Front & Adjacent – Right") {
            $('#CarWallsLHS').show();
            $('#CarWallsRHS').hide();
            $('#CarWallsRear').show();
            $('#CarWallsLHSLabel').show();
            $('#CarWallsRHSLabel').hide();
            $('#CarWallsRearLabel').show();
        }
        $('#DivDoor2').show();
        $('#DiSecondEntLanDoor').show();
    }
    if ($("#DoorEntType1").val() == "Front & Second entrance") {
        $('#DivDoorEntType2').show();
        $('#DivLDFDoorType2').show();
    }
    else {
        $('#DivDoorEntType2').hide();
        $('#DivLDFDoorType2').hide();
    }

    if ($("#DoorEntType3").val() == "Front & Second entrance") {
        $('#DivDoorEntType4').show();
        $('#DivLDFDoorType4').show();
    }
    else {
        $('#DivDoorEntType4').hide();
        $('#DivLDFDoorType4').hide();
    }

    if ($("#DoorEntType5").val() == "Front & Second entrance") {
        $('#DivDoorEntType6').show();
        $('#DivLDFDoorType6').show();
    }
    else {
        $('#DivDoorEntType6').hide();
        $('#DivLDFDoorType6').hide();
    }


    if ($("#DoorEntType7").val() == "Front & Second entrance") {
        $('#DivDoorEntType8').show();
        $('#DivLDFDoorType8').show();
    }
    else {
        $('#DivDoorEntType8').hide();
        $('#DivLDFDoorType8').hide();
    }


    if ($("#DoorEntType9").val() == "Front & Second entrance") {
        $('#DivDoorEntType10').show();
        $('#DivLDFDoorType10').show();

    }
    else {
        $('#DivDoorEntType10').hide();
        $('#DivLDFDoorType10').hide();
    }

}

function setEntrance1() {
    $(DoorEntType1).html('');
    $(DoorEntType3).html('');
    $(DoorEntType5).html('');
    $(DoorEntType7).html('');
    $(DoorEntType9).html('');


    if ($("#entranceType").val() == "Front entrance") {
        $(DoorEntType1).append('<option value="Front entrance">Front entrance</option>');
        $(DoorEntType3).append('<option value="Front entrance">Front entrance</option>');
        $(DoorEntType5).append('<option value="Front entrance">Front entrance</option>');
        $(DoorEntType7).append('<option value="Front entrance">Front entrance</option>');
        $(DoorEntType9).append('<option value="Front entrance">Front entrance</option>');


    }
    else {

        $(DoorEntType1).append('<option value="Front entrance">Front entrance</option>');
        $(DoorEntType3).append('<option value="Front entrance">Front entrance</option>');
        $(DoorEntType5).append('<option value="Front entrance">Front entrance</option>');
        $(DoorEntType7).append('<option value="Front entrance">Front entrance</option>');
        $(DoorEntType9).append('<option value="Front entrance">Front entrance</option>');
        if ($("#entranceType").val() != "Front & Rear entrance") {
            $(DoorEntType1).append('<option value="Second entrance">Second entrance</option>');
        }
        $(DoorEntType3).append('<option value="Second entrance">Second entrance</option>');
        $(DoorEntType5).append('<option value="Second entrance">Second entrance</option>');
        $(DoorEntType7).append('<option value="Second entrance">Second entrance</option>');
        $(DoorEntType9).append('<option value="Second entrance">Second entrance</option>');


        $(DoorEntType1).append('<option value="Front & Second entrance">Front & Second entrance</option>');
        $(DoorEntType3).append('<option value="Front & Second entrance">Front & Second entrance</option>');
        $(DoorEntType5).append('<option value="Front & Second entrance">Front & Second entrance</option>');
        $(DoorEntType7).append('<option value="Front & Second entrance">Front & Second entrance</option>');
        $(DoorEntType9).append('<option value="Front & Second entrance">Front & Second entrance</option>');
    }
}

function part12ChangeOnLoad() {
    if ($('#Part12').is(":checked")) {
        $("#CarDisplayType").html('');
        $("#CarDisplayType").append('<option value="Icaro blue">Icaro blue</option>');
        $("#CarDisplayType").append('<option value="Icaro black">Icaro black</option>');
        $("#CarDisplayType").append('<option value="Icaro blue gold frame">Icaro blue gold frame</option>');
        $("#CarDisplayType").append('<option value="Icaro black gold frame">Icaro black gold frame</option>');
        $("#CarDisplayType").append('<option value="tricolour blue">tricolour blue</option>');
        $("#CarDisplayType").append('<option value="tricolour black">tricolour black</option>');
        $("#CarDisplayType").append('<option value="Tricolour blue gold frame">Tricolour blue gold frame</option>');
        $("#CarDisplayType").append('<option value="tricolour black gold frame ">tricolour black gold frame </option>');

        if ($("#NoOfFloors").val() == "2") {
            $("#Gong").prop("checked", false);
        }
        else {
            $("#Gong").prop("checked", true);
            $("#VoiceSynt").prop("checked", true);
            $(CarDisplayTypeLoc).find('option').filter(function () {
                return this.text === 'Icaro blue';
            }).attr('selected', 'selected');
            $("#AllLevels").prop("checked", true);
        }
        $(HandRailType).find('option').filter(function () {
            return this.text === 'Round stainless steel with rounded corners';
        }).attr('selected', 'selected');
        $("#CopLocDCOP").prop("checked", true);
    }
}

function part12Change() {
   
    if ($('#Part12').is(":checked")) {
       
        $("#CarDisplayType").html('');
        $("#CarDisplayType").append('<option value="Icaro blue">Icaro blue</option>');
        $("#CarDisplayType").append('<option value="Icaro black">Icaro black</option>');
        $("#CarDisplayType").append('<option value="Icaro blue gold frame">Icaro blue gold frame</option>');
        $("#CarDisplayType").append('<option value="Icaro black gold frame">Icaro black gold frame</option>');
        $("#CarDisplayType").append('<option value="tricolour blue">tricolour blue</option>');
        $("#CarDisplayType").append('<option value="tricolour black">tricolour black</option>');
        $("#CarDisplayType").append('<option value="Tricolour blue gold frame">Tricolour blue gold frame</option>');
        $("#CarDisplayType").append('<option value="tricolour black gold frame ">tricolour black gold frame </option>');

        if ($("#NoOfFloors").val() == "2") {
            $("#Gong").prop("checked", false);
        }
        else {
            $("#Gong").prop("checked", true);
            $("#VoiceSynt").prop("checked", true);
            $(CarDisplayTypeLoc).find('option').filter(function () {
                return this.text === 'Icaro blue';
            }).attr('selected', 'selected');
            $("#AllLevels").prop("checked", true);
        }
        $(HandRailType).find('option').filter(function () {
            return this.text === 'Round stainless steel with rounded corners';
        }).attr('selected', 'selected');
        $("#CopLocDCOP").prop("checked", true);
    }
    else {
        $("#CarDisplayType").html('');
        if (!($("#LiftType").val == "Domus Evolution")) {
            $("#CarDisplayType").append('<option value="No Display">No Display</option>');
        }
        $("#CarDisplayType").append('<option value="Icaro blue">Icaro blue</option>');
        $("#CarDisplayType").append('<option value="Icaro black">Icaro black</option>');
        $("#CarDisplayType").append('<option value="Icaro blue gold frame">Icaro blue gold frame</option>');
        $("#CarDisplayType").append('<option value="Icaro black gold frame">Icaro black gold frame</option>');
        $("#CarDisplayType").append('<option value="tricolour blue">tricolour blue</option>');
        $("#CarDisplayType").append('<option value="tricolour black">tricolour black</option>');
        $("#CarDisplayType").append('<option value="Tricolour blue gold frame">Tricolour blue gold frame</option>');
        $("#CarDisplayType").append('<option value="tricolour black gold frame ">tricolour black gold frame </option>');
        $("#Gong").prop("checked", false);
        $("#VoiceSynt").prop("checked", false);
        $("#CopLocDCOP").prop("checked", false);

        $(HandRailType).find('option').filter(function () {
            return this.text === 'No Handrail';
        }).attr('selected', 'selected');
        $(CarDisplayTypeLoc).find('option').filter(function () {
            return this.text === 'No Display';
        }).attr('selected', 'selected');
        $("#AllLevels").prop("checked", false);
    }
}

function floorsChange() {
    if ($(NoOfFloors).val() == "2") {
        $('#Level3H').hide();
        $('#Level4H').hide();
        $('#Level5H').hide();
        $('#DivDoorEntType5').hide();
        $('#DivDoorEntType7').hide();
        $('#DivDoorEntType9').hide();
        $('#FtoFD2').hide();
        $('#FtoFD3').hide();
        $('#FtoFD4').hide();


    }
    else if ($(NoOfFloors).val() == "3") {
        $('#Level4H').hide();
        $('#Level5H').hide();
        $('#Level3H').show();
        $('#DivDoorEntType5').show();
        $('#DivDoorEntType7').hide();
        $('#DivDoorEntType9').hide();

        $('#DivLDFDoorType5').show();
        $('#DivLDFDoorType7').hide();
        $('#DivLDFDoorType9').hide();

        $('#FtoFD2').show();
        $('#FtoFD3').hide();
        $('#FtoFD4').hide();
    }
    else if ($(NoOfFloors).val() == "4") {
        //$("#Travel").val("9000");
        $('#Level5H').hide();
        $('#Level3H').show();
        $('#Level4H').show();
        $('#DivDoorEntType5').show();
        $('#DivDoorEntType7').show();
        $('#DivDoorEntType9').hide();

        $('#DivLDFDoorType5').show();
        $('#DivLDFDoorType7').show();
        $('#DivLDFDoorType9').hide();

        $('#FtoFD2').show();
        $('#FtoFD3').show();
        $('#FtoFD4').hide();

    }
    else if ($(NoOfFloors).val() == "5") {
        //$("#Travel").val("12000");
        $('#Level3H').show();
        $('#Level4H').show();
        $('#Level5H').show();
        $('#DivDoorEntType5').show();
        $('#DivDoorEntType7').show();
        $('#DivDoorEntType9').show();
        $('#DivLDFDoorType5').show();
        $('#DivLDFDoorType7').show();
        $('#DivLDFDoorType9').show();

        $('#FtoFD2').show();
        $('#FtoFD3').show();
        $('#FtoFD4').show();
    }

    var val1 = 0;
    var val2 = 0;
    var val3 = 0;
    var val4 = 0;

    if ($('#FtoFD1').css("display") != 'none') {
        val1 = parseInt($('#FtoFDistance1').val());
    }

    if ($('#FtoFD2').css("display") != 'none') {
        val2 = parseInt($('#FtoFDistance2').val());
    }
    if ($('#FtoFD3').css("display") != 'none') {
        val3 = parseInt($('#FtoFDistance3').val());
    }
    if ($('#FtoFD4').css("display") != 'none') {
        val4 = parseInt($('#FtoFDistance4').val());
    }

    $("#Travel").val(val1+val2+val3+val4);
}

function setLadingDoor() {
    $("#FrontEntLanDoor").html('');
    $("#SecondEntLanDoor").html('');
    $("#FrontEntCarDoor").html('');
    $("#SecondEntCarDoor").html('');

    $("#FrontEntCarDoorFinish").html('');
    $("#SecondEntCarDoorFinish").html('');

    if ($("#LiftType").val() == "Domus Evolution") {
         $("#FrontEntLanDoor").append('<option value="Automatic sliding">Automatic sliding</option>');
        $("#SecondEntLanDoor").append('<option value="Automatic sliding">Automatic sliding</option>');
        $("#FrontEntCarDoor").append('<option value="Automatic sliding">Automatic sliding</option>');
        $("#SecondEntCarDoor").append('<option value="Automatic sliding">Automatic sliding</option>');

        $("#FrontEntCarDoorFinish").append('<option value="===Stainless Steel===">===Stainless Steel===</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Brushed Stainless Steel">Brushed Stainless Steel</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Mirror Stainless Steel">Mirror Stainless Steel</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Stainless Steel 132- leather">Stainless Steel 132- leather</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Stainless Steel 145 - Avesta 9">Stainless Steel 145 - Avesta 9</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Stainless Steel 131 - chequered">Stainless Steel 131 - chequered</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Automatic sliding– closing to right">Automatic sliding– closing to right</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Stainless Steel 150 - Blue Squared">Stainless Steel 150 - Blue Squared</option>');
        $("#FrontEntCarDoorFinish").append('<option value="===Painting===">===Painting===</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Primed Painted (finishing by customer)">Primed Painted (finishing by customer)</option>');
        $("#FrontEntCarDoorFinish").append('<option value="RAL painted std (colour to be defined)">RAL painted std (colour to be defined)</option>');
        $("#FrontEntCarDoorFinish").append('<option value="RAL painted  9010 pure white">RAL painted  9010 pure white</option>');
        $("#FrontEntCarDoorFinish").append('<option value="RAL painted 7001 silver grey">RAL painted 7001 silver grey</option>');
        $("#FrontEntCarDoorFinish").append('<option value="RAL painted 5023 distant blue">RAL painted 5023 distant blue</option>');
        $("#FrontEntCarDoorFinish").append('<option value="RAL painted 5011 steel blue">RAL painted 5011 steel blue</option>');
        $("#FrontEntCarDoorFinish").append('<option value="RAL painted 6010 grass green">RAL painted 6010 grass green</option>');
        $("#FrontEntCarDoorFinish").append('<option value="RAL painted 3003 Ruby Red">RAL painted 3003 Ruby Red</option>');
        $("#FrontEntCarDoorFinish").append('<option value="RAL painted 1013 pearl white">RAL painted 1013 pearl white</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Special RAL painted">Special RAL painted</option>');
        $("#FrontEntCarDoorFinish").append('<option value="===Glass===">===Glass===</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Trasparent Glass with brushed stainless steel frame">Trasparent Glass with brushed stainless steel frame</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Trasparent Glass with Mirror stainless steel frame">Trasparent Glass with Mirror stainless steel frame</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Trasparent Glass with film">Trasparent Glass with film</option>');
        $("#FrontEntCarDoorFinish").append('<option value="===Skinplate===">===Skinplate===</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Skinplate DL81E">Skinplate DL81E</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Skinplate A90GTA">Skinplate A90GTA</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Skinplate DL86">Skinplate DL86</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Skinplate M12">Skinplate M12</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Skinplate B32SMA">Skinplate B32SMA</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Skinplate G22SMA">Skinplate G22SMA</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Skinplate G21SMA">Skinplate G21SMA</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Skinplate R8SME Dark Red">Skinplate R8SME Dark Red</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Skinplate A32PP - Polished Effect">Skinplate A32PP - Polished Effect</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Skinplate F2SMA silver grey">Skinplate F2SMA silver grey</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Skinplate F42PPS brushed stainless steel">Skinplate F42PPS brushed stainless steel</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Skinplate F12PPS polished stainless steel">Skinplate F12PPS polished stainless steel</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Skinplate Special">Skinplate Special</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Plastic Laminate">Plastic Laminate</option>');
        $("#FrontEntCarDoorFinish").append('<option value="Adhesive Film">Adhesive Film</option>');


        //  if ($(DiSecondEntLanDoor).is(":visible")){
        $("#SecondEntCarDoorFinish").append('<option value="===Stainless Steel===">===Stainless Steel===</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Brushed Stainless Steel">Brushed Stainless Steel</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Mirror Stainless Steel">Mirror Stainless Steel</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Stainless Steel 132- leather">Stainless Steel 132- leather</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Stainless Steel 145 - Avesta 9">Stainless Steel 145 - Avesta 9</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Stainless Steel 131 - chequered">Stainless Steel 131 - chequered</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Automatic sliding– closing to right">Automatic sliding– closing to right</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Stainless Steel 150 - Blue Squared">Stainless Steel 150 - Blue Squared</option>');
        $("#SecondEntCarDoorFinish").append('<option value="===Painting===">===Painting===</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Primed Painted (finishing by customer)">Primed Painted (finishing by customer)</option>');
        $("#SecondEntCarDoorFinish").append('<option value="RAL painted std (colour to be defined)">RAL painted std (colour to be defined)</option>');
        $("#SecondEntCarDoorFinish").append('<option value="RAL painted  9010 pure white">RAL painted  9010 pure white</option>');
        $("#SecondEntCarDoorFinish").append('<option value="RAL painted 7001 silver grey">RAL painted 7001 silver grey</option>');
        $("#SecondEntCarDoorFinish").append('<option value="RAL painted 5023 distant blue">RAL painted 5023 distant blue</option>');
        $("#SecondEntCarDoorFinish").append('<option value="RAL painted 5011 steel blue">RAL painted 5011 steel blue</option>');
        $("#SecondEntCarDoorFinish").append('<option value="RAL painted 6010 grass green">RAL painted 6010 grass green</option>');
        $("#SecondEntCarDoorFinish").append('<option value="RAL painted 3003 Ruby Red">RAL painted 3003 Ruby Red</option>');
        $("#SecondEntCarDoorFinish").append('<option value="RAL painted 1013 pearl white">RAL painted 1013 pearl white</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Special RAL painted">Special RAL painted</option>');
        $("#SecondEntCarDoorFinish").append('<option value="===Glass===">===Glass===</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Trasparent Glass with brushed stainless steel frame">Trasparent Glass with brushed stainless steel frame</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Trasparent Glass with Mirror stainless steel frame">Trasparent Glass with Mirror stainless steel frame</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Trasparent Glass with film">Trasparent Glass with film</option>');
        $("#SecondEntCarDoorFinish").append('<option value="===Skinplate===">===Skinplate===</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Skinplate DL81E">Skinplate DL81E</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Skinplate A90GTA">Skinplate A90GTA</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Skinplate DL86">Skinplate DL86</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Skinplate M12">Skinplate M12</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Skinplate B32SMA">Skinplate B32SMA</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Skinplate G22SMA">Skinplate G22SMA</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Skinplate G21SMA">Skinplate G21SMA</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Skinplate R8SME Dark Red">Skinplate R8SME Dark Red</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Skinplate A32PP - Polished Effect">Skinplate A32PP - Polished Effect</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Skinplate F2SMA silver grey">Skinplate F2SMA silver grey</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Skinplate F42PPS brushed stainless steel">Skinplate F42PPS brushed stainless steel</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Skinplate F12PPS polished stainless steel">Skinplate F12PPS polished stainless steel</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Skinplate Special">Skinplate Special</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Plastic Laminate">Plastic Laminate</option>');
        $("#SecondEntCarDoorFinish").append('<option value="Adhesive Film">Adhesive Film</option>');
        //}
        if ($('#hidden1').val() != "N/A") {
            $('#FrontEntCarDoorFinish').val($('#hidden1').val());
        }
        else {
            $('#FrontEntCarDoorFinish').val("Brushed Stainless Steel");
        }
        
        if ($('#hidden2').val() != "N/A") {
            $('#SecondEntCarDoorFinish').val($('#hidden2').val());
        }
        else {
            $('#SecondEntCarDoorFinish').val("Brushed Stainless Steel");
        }
    }
    else {

        $("#FrontEntLanDoor").append('<option value="Swing doors">Swing doors</option>');
        $("#SecondEntLanDoor").append('<option value="Swing doors">Swing doors</option>');

        $("#FrontEntCarDoor").append('<option value="N/A">N/A</option>');
        $("#SecondEntCarDoor").append('<option value="N/A">N/A</option>');
        $("#FrontEntCarDoorFinish").append('<option value="N/A">N/A</option>');
        $("#SecondEntCarDoorFinish").append('<option value="N/A">N/A</option>');



    }
}

function setDoorHandel() {
    $("#LDFDoorHandle1").html('');
    $("#LDFDoorHandle2").html('');
    $("#LDFDoorHandle3").html('');
    $("#LDFDoorHandle4").html('');
    $("#LDFDoorHandle5").html('');
    $("#LDFDoorHandle6").html('');
    $("#LDFDoorHandle7").html('');
    $("#LDFDoorHandle8").html('');
    $("#LDFDoorHandle9").html('');
    $("#LDFDoorHandle10").html('');


    $("#StructureType").html('');

    if ($("#LiftType").val() == "Domus Evolution") {
        $("#LDFDoorHandle1").append('<option value="N/A">N/A</option>');
        $('#LDFAutoDoorOpener1').attr("disabled", true);
        $("#LDFDoorHandle2").append('<option value="N/A">N/A</option>');
        $('#LDFAutoDoorOpener2').attr("disabled", true);
        $("#LDFDoorHandle3").append('<option value="N/A">N/A</option>');
        $('#LDFAutoDoorOpener3').attr("disabled", true);
        $("#LDFDoorHandle4").append('<option value="N/A">N/A</option>');
        $('#LDFAutoDoorOpener4').attr("disabled", true);
        $("#LDFDoorHandle5").append('<option value="N/A">N/A</option>');
        $('#LDFAutoDoorOpener5').attr("disabled", true);
        $("#LDFDoorHandle6").append('<option value="N/A">N/A</option>');
        $('#LDFAutoDoorOpener6').attr("disabled", true);
        $("#LDFDoorHandle7").append('<option value="N/A">N/A</option>');
        $('#LDFAutoDoorOpener7').attr("disabled", true);
        $("#LDFDoorHandle8").append('<option value="N/A">N/A</option>');
        $('#LDFAutoDoorOpener8').attr("disabled", true);
        $("#LDFDoorHandle9").append('<option value="N/A">N/A</option>');
        $('#LDFAutoDoorOpener9').attr("disabled", true);
        $("#LDFDoorHandle10").append('<option value="N/A">N/A</option>');
        $('#LDFAutoDoorOpener10').attr("disabled", true);

        $("#StructureType").append('<option value="Steel">Steel</option>');

    }
    else {

        $("#StructureType").append('<option value="Aluminium">Aluminium</option>');
        if ($("#LiftType").val() == "DomusLift") {
            $("#StructureType").append('<option value="Steel">Steel</option>');
        }
        $("#LDFDoorHandle1").append('<option value="Natural anodised aluminium">Natural anodised aluminium</option>');
        $("#LDFDoorHandle1").append('<option value="Shiny anodised aluminium">Shiny anodised aluminium</option>');
        $("#LDFDoorHandle1").append('<option value="Golden">Golden</option>');
        $("#LDFDoorHandle1").append('<option value="RAL">RAL</option>');
        $("#LDFDoorHandle1").append('<option value="No Handle">No Handle</option>');
        $("#LDFDoorHandle1").append('<option value="Standard black">Standard black</option>');
        $('#LDFAutoDoorOpener1').attr("disabled", false);

        $("#LDFDoorHandle2").append('<option value="Natural anodised aluminium">Natural anodised aluminium</option>');
        $("#LDFDoorHandle2").append('<option value="Shiny anodised aluminium">Shiny anodised aluminium</option>');
        $("#LDFDoorHandle2").append('<option value="Golden">Golden</option>');
        $("#LDFDoorHandle2").append('<option value="RAL">RAL</option>');
        $("#LDFDoorHandle2").append('<option value="No Handle">No Handle</option>');
        $("#LDFDoorHandle2").append('<option value="Standard black">Standard black</option>');
        $('#LDFAutoDoorOpener2').attr("disabled", false);

        $("#LDFDoorHandle3").append('<option value="Natural anodised aluminium">Natural anodised aluminium</option>');
        $("#LDFDoorHandle3").append('<option value="Shiny anodised aluminium">Shiny anodised aluminium</option>');
        $("#LDFDoorHandle3").append('<option value="Golden">Golden</option>');
        $("#LDFDoorHandle3").append('<option value="RAL">RAL</option>');
        $("#LDFDoorHandle3").append('<option value="No Handle">No Handle</option>');
        $("#LDFDoorHandle3").append('<option value="Standard black">Standard black</option>');
        $('#LDFAutoDoorOpener3').attr("disabled", false);

        $("#LDFDoorHandle4").append('<option value="Natural anodised aluminium">Natural anodised aluminium</option>');
        $("#LDFDoorHandle4").append('<option value="Shiny anodised aluminium">Shiny anodised aluminium</option>');
        $("#LDFDoorHandle4").append('<option value="Golden">Golden</option>');
        $("#LDFDoorHandle4").append('<option value="RAL">RAL</option>');
        $("#LDFDoorHandle4").append('<option value="No Handle">No Handle</option>');
        $("#LDFDoorHandle4").append('<option value="Standard black">Standard black</option>');
        $('#LDFAutoDoorOpener4').attr("disabled", false);

        $("#LDFDoorHandle5").append('<option value="Natural anodised aluminium">Natural anodised aluminium</option>');
        $("#LDFDoorHandle5").append('<option value="Shiny anodised aluminium">Shiny anodised aluminium</option>');
        $("#LDFDoorHandle5").append('<option value="Golden">Golden</option>');
        $("#LDFDoorHandle5").append('<option value="RAL">RAL</option>');
        $("#LDFDoorHandle5").append('<option value="No Handle">No Handle</option>');
        $("#LDFDoorHandle5").append('<option value="Standard black">Standard black</option>');
        $('#LDFAutoDoorOpener5').attr("disabled", false);


        $("#LDFDoorHandle6").append('<option value="Natural anodised aluminium">Natural anodised aluminium</option>');
        $("#LDFDoorHandle6").append('<option value="Shiny anodised aluminium">Shiny anodised aluminium</option>');
        $("#LDFDoorHandle6").append('<option value="Golden">Golden</option>');
        $("#LDFDoorHandle6").append('<option value="RAL">RAL</option>');
        $("#LDFDoorHandle6").append('<option value="No Handle">No Handle</option>');
        $("#LDFDoorHandle6").append('<option value="Standard black">Standard black</option>');
        $('#LDFAutoDoorOpener6').attr("disabled", false);

        $("#LDFDoorHandle7").append('<option value="Natural anodised aluminium">Natural anodised aluminium</option>');
        $("#LDFDoorHandle7").append('<option value="Shiny anodised aluminium">Shiny anodised aluminium</option>');
        $("#LDFDoorHandle7").append('<option value="Golden">Golden</option>');
        $("#LDFDoorHandle7").append('<option value="RAL">RAL</option>');
        $("#LDFDoorHandle7").append('<option value="No Handle">No Handle</option>');
        $("#LDFDoorHandle7").append('<option value="Standard black">Standard black</option>');
        $('#LDFAutoDoorOpener7').attr("disabled", false);

        $("#LDFDoorHandle8").append('<option value="Natural anodised aluminium">Natural anodised aluminium</option>');
        $("#LDFDoorHandle8").append('<option value="Shiny anodised aluminium">Shiny anodised aluminium</option>');
        $("#LDFDoorHandle8").append('<option value="Golden">Golden</option>');
        $("#LDFDoorHandle8").append('<option value="RAL">RAL</option>');
        $("#LDFDoorHandle8").append('<option value="No Handle">No Handle</option>');
        $("#LDFDoorHandle8").append('<option value="Standard black">Standard black</option>');
        $('#LDFAutoDoorOpener8').attr("disabled", false);

        $("#LDFDoorHandle9").append('<option value="Natural anodised aluminium">Natural anodised aluminium</option>');
        $("#LDFDoorHandle9").append('<option value="Shiny anodised aluminium">Shiny anodised aluminium</option>');
        $("#LDFDoorHandle9").append('<option value="Golden">Golden</option>');
        $("#LDFDoorHandle9").append('<option value="RAL">RAL</option>');
        $("#LDFDoorHandle9").append('<option value="No Handle">No Handle</option>');
        $("#LDFDoorHandle9").append('<option value="Standard black">Standard black</option>');
        $('#LDFAutoDoorOpener9').attr("disabled", false);


        $("#LDFDoorHandle10").append('<option value="Natural anodised aluminium">Natural anodised aluminium</option>');
        $("#LDFDoorHandle10").append('<option value="Shiny anodised aluminium">Shiny anodised aluminium</option>');
        $("#LDFDoorHandle10").append('<option value="Golden">Golden</option>');
        $("#LDFDoorHandle10").append('<option value="RAL">RAL</option>');
        $("#LDFDoorHandle10").append('<option value="No Handle">No Handle</option>');
        $("#LDFDoorHandle10").append('<option value="Standard black">Standard black</option>');
        $('#LDFAutoDoorOpener10').attr("disabled", false);

    }

}

function getstructurefinish() {
    // alert("Something seems Wrong11");
    $.ajax({
        url: $("#GetStructureFinish").val(),
        type: 'POST',
        data: {
            Value: $("#StructureType").val(),

            // Id: $(this).val(),
        },
        success: function (vv) {

            $("#StructureFinish").html('');
            $.each(vv, function (i, states) {
                $("#StructureFinish").append('<option value="' + states.Value + '">' +
                     states.Text + '</option>');
                // here we are adding option for States
                // alert("Something seems Wrong22");
            });
            //  $('#LiftType').val(vv[0].Value).trigger('change');
            // $('#liftModel').val(vv[0].Value).trigger('change');
        },
        error: function (xhr) { alert("Something seems Wrong"); }
    });

}

function onPowerChange()
{

    if ($("#power").val() != "Three Phase") {

        if ($('#LiftType').val() == 'DomusXL Spirit' || $('#LiftType').val() == 'Domus Spirit' || $('#codeComplence').val() == 'Part 15') {
          
            $("#Speed").html('');
            $("#Speed").append('<option value="0.15">0.15</option>');
            $("#Pit").val("130");

        }
        else {
            if ($('#LiftType').val() == 'DomusXL' & $('#codeComplence').val() == 'Part 15') {
            }
            else {
                $("#Speed").empty();

                $("#Speed").append('<option value="0.25">0.25</option>');
                $("#Speed").append('<option value="0.3">0.3</option>');
                if ($('#LiftType').val() == 'Domus Evolution') {
                    $('#Speed').find('option').filter(function () {
                        return this.text === '0.25';
                    }).attr('selected', 'selected');
                    $('#Pit').val('150');
                }
                else {
                    $('#Speed').find('option').filter(function () {
                        return this.text === '0.25';
                    }).attr('selected', 'selected');
                    $('#Pit').val('130');
                }


            }
        }

    }
    else
    {

            $("#Speed").empty();
            $("#Speed").append('<option value="0.3">0.3</option>');
            $('#Pit').val('150');
    }
}

function onPart12Change()
{
    if ($('#codeComplence').val() != "Part 18") {
        $("#CarKeySwitch").prop("checked", true);
        $("#LandingKeySwitch").prop("checked", true);
    }
    else {
        $("#CarKeySwitch").prop("checked", false);
        $("#LandingKeySwitch").prop("checked", false);

    }
}

$('#editForm').submit(function () {


    var val1 = 0;
    var val2 = 0;
    var val3 = 0;
    var val4 = 0;

    if($('#FtoFD1').css("display") != 'none')
    {
        val1 = parseInt($('#FtoFDistance1').val());
    }

    if ($('#FtoFD2').css("display") != 'none') {
        val2 = parseInt($('#FtoFDistance2').val());
    }
    if ($('#FtoFD3').css("display") != 'none') {
        val3 = parseInt($('#FtoFDistance3').val());
    }
    if ($('#FtoFD4').css("display") != 'none') {
        val4 = parseInt($('#FtoFDistance4').val());
    }
    

    if (!($('#Travel').val() == (val1 + val2 + val3 + val4))) {
        alert("The Travel should be equal to sum of floor to floor distance.")
        return false;
    }

    if ($('#SellingPrice').val() == 0 || $('#SellingPrice1').val() == 0 || $('#TotalSellingPrice').val() == 0 || $('#TotalSellingPrice1').val() == 0) {
        alert('Please enter the pricing details.');
        return false;
    }

    if (($('#loadBearingWall').val() === 'Left' & ($('#CarWallsLHS').val().toUpperCase().indexOf('GLASS')) >= 0)
        | ($('#loadBearingWall').val() === 'Right' & ($('#CarWallsRHS').val().toUpperCase().indexOf('GLASS')) >= 0)
        | ($('#loadBearingWall').val() === 'Rear' & ($('#CarWallsRear').val().toUpperCase().indexOf('GLASS')) >= 0)) {
        alert('For Rail Wall- ' + $('#loadBearingWall').val()+', '+ $('#loadBearingWall').val()+' Car wall can not be Glass Type.');
        return false;
    }
    else {
        return true;
    }

    if ($('#entranceType').val() === 'Front & Rear entrance') {

        if ($('#DoorEntType1').val() === 'Front entrance' & $('#DoorEntType3').val() === 'Front entrance' &
            $('#DoorEntType5').val() === 'Front entrance' & $('#DoorEntType7').val() === 'Front entrance' &
            $('#DoorEntType9').val() === 'Front entrance') {
            alert('Atleast one entrance type must be second or First & secount entrance.');
            return false;
        }
        else {
            return true;
        }
    }
    else {
        return true;
    }


   
});

function LiftModelCapacityChange()
{


    var value = $('#capacity').val().replace(' Kg', '');
    
    if (!($('#liftModel').val().toLowerCase().indexOf('special') >= 0)) {
        if ($('#liftModel').val() == '1C/1' ||
            $('#liftModel').val() == '1C/2' ||
            $('#liftModel').val() == '1C/3' ||
            $('#liftModel').val() == '1C/6' ||
            $('#liftModel').val() == '1C/7' ||
            $('#liftModel').val() == '2P/1' ||
            $('#liftModel').val() == '2P/2' ||
            $('#liftModel').val() == '2P/3' ||
            $('#liftModel').val() == '2P/6' ||       
            $('#liftModel').val() == '2P/7' ||
            $('#liftModel').val() == '2A/1' ||
            $('#liftModel').val() == '2A/2' ||
            $('#liftModel').val() == '2A/3' ||
            $('#liftModel').val() == '2A/6' ||
            $('#liftModel').val() == '1L/1' ||
            $('#liftModel').val() == '1L/2' ||
            $('#liftModel').val() == '1L/3' ||
            $('#liftModel').val() == '1L/6' ||
            $('#liftModel').val() == '2L/1' ||
            $('#liftModel').val() == '2L/2' ||
            $('#liftModel').val() == '2L/3' ||
            $('#liftModel').val() == '2L/6' ||
            $('#liftModel').val() == '2L/7' ||
            $('#liftModel').val() == 'RS-1C/4' ||
            $('#liftModel').val() == 'RS-2P/4' ||
           $('#liftModel').val() == 'RS-2A/4') {
            $("#capacity").html('');
            $("#capacity").append('<option value="' + '300' + '">' +'300 Kg' + '</option>');
        }


  if($('#liftModel').val() == '2A/9' ||
    $('#liftModel').val() == '1C/8' ||
    $('#liftModel').val() == '2P/8' ||
    $('#liftModel').val() == '1C/12'||
    $('#liftModel').val() == '1C/4'||
    $('#liftModel').val() == '1C/7'||
    $('#liftModel').val() == '1L/4'||
    $('#liftModel').val() == '1L/7'||
    $('#liftModel').val() == '1A/4'||
    $('#liftModel').val() == '1A/7'||
    $('#liftModel').val() == '1P/4') 
  {
            $("#capacity").html('');
            $("#capacity").append('<option value="' + '400' + '">' +
             '400 Kg' + '</option>');
   }

        if ($('#liftModel').val() == '2A/small' ||
            $('#liftModel').val() == '1C/small' ||
            $('#liftModel').val() == '1L/small' ||
            $('#liftModel').val() == '2P/small') {
            $("#capacity").html('');
            $("#capacity").append('<option value="' + '250' + '">' +
             '250 Kg' + '</option>');

        }

        if ($('#liftModel').val() == '1C/5' ||
            $('#liftModel').val() == '1L/5' ||
            $('#liftModel').val() == '2P/5' ||
            $('#liftModel').val() == '2A/5' ) {
            $("#capacity").html('');
            $("#capacity").append('<option value="' + '340' + '">' +
     '340 Kg' + '</option>');
        }

        if ($('#liftModel').val() == '2A/4' ||
            $('#liftModel').val() == '2P/4' ||
            $('#liftModel').val() == '2P/4') {
            $("#capacity").html('');
            $("#capacity").append('<option value="' + '340' + '">' +'340 Kg' + '</option>');
            $("#capacity").append('<option value="' + '400' + '">' +'400 Kg' + '</option>');
            if (value == '340' || value == '400') {
                $("#capacity").val(value);
            }
        }

        if ($('#liftModel').val() == '2A/7' ||
            $('#liftModel').val() == '1L/7') {
            $("#capacity").html('');
            $("#capacity").append('<option value="' + '300' + '">' +'300 Kg' + '</option>');
            $("#capacity").append('<option value="' + '340' + '">' +'340 Kg' + '</option>');
            $("#capacity").append('<option value="' + '400' + '">' +'400 Kg' + '</option>');
            if (value == '300' || value == '340' || value == '400') {
                $("#capacity").val(value);
            }
        }
    }
    else {
        
        $("#capacity").html('');
        $("#capacity").append('<option value="' + '250' + '">' +'250 Kg' + '</option>');
        $("#capacity").append('<option value="' + '300' + '">' +'300 Kg' + '</option>');
        $("#capacity").append('<option value="' + '340' + '">' +'340 Kg' + '</option>');
        $("#capacity").append('<option value="' + '400' + '">' +'400 Kg' + '</option>');
        if (value='250' || value == '300' || value == '340' || value == '400') {
            $("#capacity").val(value);
        }
    }


    if ($('#LiftType').val() === "DomusXL" || $('#LiftType').val() === "Domus Evolution") {
        $("#capacity").html('');
        $("#capacity").append('<option value="' + '400' + '">' +'400 Kg' + '</option>');
        $("#capacity").val("400");
    }

    if ($('#LiftType').val() === "Domus Spirit") {
        if($("#isType").val() == "Commercial")
        {
            $("#capacity").html('');
            $("#capacity").append('<option value="' + '340' + '">' +'340 Kg' + '</option>');

        }
        else
            {
            if ($('#liftModel').val().toLowerCase().indexOf("special") > 0) {
                $("#capacity").html('');
                $("#capacity").append('<option value="' + '250' + '">' + '250 Kg' + '</option>');
                $("#capacity").append('<option value="' + '300' + '">' + '300 Kg' + '</option>');
                $("#capacity").append('<option value="' + '340' + '">' + '340 Kg' + '</option>');
                $("#capacity").append('<option value="' + '400' + '">' + '400 Kg' + '</option>');
                if (value = '250' || value == '300' || value == '340' || value == '400') {
                    $("#capacity").val(value);
                }
            }
            else {
                $("#capacity").html('');
                $("#capacity").append('<option value="' + '340' + '">' + '340 Kg' + '</option>');
                $("#capacity").val("340");
            }
            }
    }


}

function changeCodeComplaince() {
   
    var url = $('#getCodeCom').val();
    $.ajax({
        url: url,
        type: 'POST',
        async: false,
        data: {
            Value: $(codeComplence).val(),

            Id: $("#Section1ModelId").val(),
        },
        success: function (vv) {

            $("#LiftType").html('');
            $.each(vv, function (i, states) {
                $("#LiftType").append('<option value="' + states.Value + '">' +
                     states.Text + '</option>');
                // here we are adding option for States

            });
            $('#LiftType').val(vv[0].Value).trigger('change');
     
//            $('#power').trigger('change');

            if ($('#LiftType').val() === 'Domus Evolution') {
                $("#CarDisplayType").val("Icaro blue");
                $('#Pit').val('150');
            }
            Rule1();
            Rule4();
        },
        error: function (xhr) { alert("Something seems Wrong"); }
    });
    Rule2();
    Rule3();
    setHandrail();
//    setSpeed();

}

