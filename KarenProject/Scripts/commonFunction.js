
function hideSDH() {
    if ($("#LiftType").val() == "Domus Evolution") {

        $('#DIvSDH').hide();
        $('#DIvSDH3', $('#DivDoorEntType3')).hide();
        $('#DIvSDH1', $('#DivDoorEntType1')).hide();
        $('#DIvSDH2', $('#DivDoorEntType2')).hide();
        $('#DIvSDH4', $('#DivDoorEntType4')).hide();
        $('#DIvSDH5', $('#DivDoorEntType5')).hide();
        $('#DIvSDH6', $('#DivDoorEntType6')).hide();
        $('#DIvSDH7', $('#DivDoorEntType7')).hide();
        $('#DIvSDH8', $('#DivDoorEntType8')).hide();
        $('#DIvSDH9', $('#DivDoorEntType9')).hide();
        $('#DIvSDH10', $('#DivDoorEntType10')).hide();
    }
    else {
        $('#DIvSDH').show();
        $('#DIvSDH3', $('#DivDoorEntType3')).show();
        $('#DIvSDH1', $('#DivDoorEntType1')).show();
        $('#DIvSDH2', $('#DivDoorEntType2')).show();
        $('#DIvSDH4', $('#DivDoorEntType4')).show();
        $('#DIvSDH5', $('#DivDoorEntType5')).show();
        $('#DIvSDH6', $('#DivDoorEntType6')).show();
        $('#DIvSDH7', $('#DivDoorEntType7')).show();
        $('#DIvSDH8', $('#DivDoorEntType8')).show();
        $('#DIvSDH9', $('#DivDoorEntType9')).show();
        $('#DIvSDH10', $('#DivDoorEntType10')).show();

    }

}

function carHeightAlert() {
    $("#CarHeight").change(function () {
        if (!($('option:selected', $("#CarHeight")).index() == 0)) {
            alert("When changing your car height, the headroom will change.");
        }
    });
}


function hideGSTPart18()
{
    if ($('#codeComplence').val() == "Part 18") {
        $('#rowGST').hide();

    }
    else {
        $('#rowGST').show();

    }
}

/*Row 223 
Added function to disable cop location at load
Depending on Rail Wall
*/

function disableCopLocOnLoad() {
    if (($("#loadBearingWall").val() == "Left")) {
        $("#CopLocLHS").prop("checked", true);
        $("#CopLocLHS").attr("disabled", true);
    }
    if (($("#loadBearingWall").val() == "Right")) {
        $("#CopLocRHS").prop("checked", true);
        $("#CopLocRHS").attr("disabled", true);
    }
    if (($("#loadBearingWall").val() == "Rear")) {
        $("#CopLocRear").prop("checked", true);
        $("#CopLocRear").attr("disabled", true);
    }
}
/*Row 226
Added function to Toggle between door closer and opener
*/

function setLDFEmbDoorCloseToggle(x)
{
    $("#LDFEmbDoorClose" + x).change(LDFEmbDoorCloseToggle);
    $("#LDFAutoDoorOpener" + x).change(LDFAutoDoorOpenerToggle);
    
}

/*Row 226
Added function calls to Toggle between door closer and opener
*/

function LDFEmbDoorCloseToggle()
{

    if ($("#FrontEntLanDoor").val() == "Swing doors")
    {
        var temp = this.id.replace("LDFEmbDoorClose", "");

        if ($("#" + this.id).is(":checked")) {
            $("#LDFAutoDoorOpener" + temp).prop("checked", false);
        }
    }
}

/*Row 226
Added function calls to Toggle between door closer and opener
*/

function LDFAutoDoorOpenerToggle() {
    if ($("#FrontEntLanDoor").val() == "Swing doors") {
        var temp = this.id.replace("LDFAutoDoorOpener", "");

        if ($("#" + this.id).is(":checked")) {
            $("#LDFEmbDoorClose" + temp).prop("checked", false);

        }
    }
}

function setSection6() {

    if ($("#ShaftType").val() == "Masonry") {
        $("#DivSection6").hide();
        $("#DivTHPartialStructHeight").hide();
    }
    else {
        $("#DivSection6").show();
        if ($(ShaftType).val() == "Top Hat") {
            $("#DivTHPartialStructHeight").show();

        }
        else {
            $("#DivTHPartialStructHeight").hide();
        }
    }
    $('#LiftType').trigger('change');
}

function disableHandrailLoc() {

    if ($("#HandRailType").val() == "No Handrail") {
        $('#HandRailLocLHS').attr("disabled", true);
        $('#HandRailLocRHS').attr("disabled", true);
        $('#HandRailLocRear').attr("disabled", true);
    }
    else {
        $('#HandRailLocLHS').attr("disabled", false);
        $('#HandRailLocRHS').attr("disabled", false);
        $('#HandRailLocRear').attr("disabled", false);
        if ($('#loadBearingWall').val() == "Left") {
            $("#HandRailLocRHS").prop("checked", false);
            $("#HandRailLocRear").prop("checked", false);
            $("#HandRailLocLHS").prop("checked", true);


        }
        else if ($(loadBearingWall).val() == "Right") {
            $("#HandRailLocLHS").prop("checked", false);
            $("#HandRailLocRear").prop("checked", false);
            $("#HandRailLocRHS").prop("checked", true);
        }
        else {
            $("#HandRailLocRear").prop("checked", true);
            $("#HandRailLocLHS").prop("checked", false);
            $("#HandRailLocRHS").prop("checked", false);

        }

    }
}

function disableMirrorLoc() {
    if ($("#MirrorType").val() == "No Mirror") {
        $('#MirrorLocLHS').attr("disabled", true);
        $('#MirrorLocRHS').attr("disabled", true);
        $('#MirrorLocRear').attr("disabled", true);
    }
    else {
        $('#MirrorLocLHS').attr("disabled", false);
        $('#MirrorLocRHS').attr("disabled", false);
        $('#MirrorLocRear').attr("disabled", false);
    }
}

function setWarranty() {
    if ($("#LiftType").val() == "DomusLift") {
        $(Warranty).find('option').filter(function () {
            return this.text === '3';
        }).attr('selected', 'selected');

    }
    else {
        $(Warranty).find('option').filter(function () {
            return this.text === '1';
        }).attr('selected', 'selected');

    }
}

function setCeilingDefault() {

    $(Ceiling).find('option').filter(function () {
        return this.text === 'White with halogen Spots';
    }).attr('selected', 'selected');


}

function setFloorDefault() {

    $(Floor).find('option').filter(function () {
        return this.text === 'Marmoleum 3866 Eternity';
    }).attr('selected', 'selected');


}

function setCladding() {
    $(CladdingLHS).html('');
    $(CladdingRHS).html('');
    $(CladdingRear).html('');
    $(CladdingFront).html('');



    if ($("#StructureType").val() == "Aluminium") {
        var arr = [
                       { val: "Transparent glass", text: "Transparent glass" },
                        { val: "Milky white glass", text: "Milky white glass" },
                         { val: "RAL Painted std colour to be defined", text: "RAL Painted std colour to be defined" },
                          { val: "RAL Painted standard", text: "RAL Painted standard" },
                           { val: "RAL Painted special", text: "RAL Painted special" },
                            { val: "Anodised Aluminium", text: "Anodised Aluminium" },
                             { val: "Brilliant Silver Aluminium", text: "Brilliant Silver Aluminium" },
                              { val: "Cherry painted Aluminium", text: "Cherry painted Aluminium" },
                               { val: "Deco White Painted Aluminium", text: "Deco White Painted Aluminium" }
        ];
        $(arr).each(function () {
            $(CladdingLHS).append($("<option>").attr('value', this.val).text(this.text));
            $(CladdingRHS).append($("<option>").attr('value', this.val).text(this.text));
            $(CladdingRear).append($("<option>").attr('value', this.val).text(this.text));
            $(CladdingFront).append($("<option>").attr('value', this.val).text(this.text));
        });
    }
    else {
        var arr = [
                         { val: "Transparent glass", text: "Transparent glass" },
                          { val: "Milky white glass", text: "Milky white glass" },
                           { val: "RAL Painted std colour to be defined", text: "RAL Painted std colour to be defined" },
                            { val: "RAL Painted standard", text: "RAL Painted standard" },
                             { val: "RAL Painted special", text: "RAL Painted special" },
                              { val: "Adhesive Film", text: "Adhesive Film" },

        ];
        $(arr).each(function () {
            $(CladdingLHS).append($("<option>").attr('value', this.val).text(this.text));
            $(CladdingRHS).append($("<option>").attr('value', this.val).text(this.text));
            $(CladdingRear).append($("<option>").attr('value', this.val).text(this.text));
            $(CladdingFront).append($("<option>").attr('value', this.val).text(this.text));
        });

    }

}

function setCOPTypeDefault() {

    $(CopType).find('option').filter(function () {
        return this.text === 'Brushed Stainless Steel plate';
    }).attr('selected', 'selected');


}

function setCOPLocation() {
    /*Row 223 
    Added lines to disable cop location 
    Depending on Rail Wall
    */

    if ($(loadBearingWall).val() == "Left") {
        $("#CopLocRHS").prop("checked", false);
        $("#CopLocRHS").removeAttr("disabled");
        $("#CopLocRear").prop("checked", false);
        $("#CopLocRear").removeAttr("disabled");
        $("#CopLocLHS").prop("checked", true);
        $("#CopLocLHS").attr("disabled", true);


    }
    else if ($(loadBearingWall).val() == "Right") {
        $("#CopLocLHS").prop("checked", false);
        $("#CopLocLHS").removeAttr("disabled");
        $("#CopLocRear").prop("checked", false);
        $("#CopLocRear").removeAttr("disabled");
        $("#CopLocRHS").prop("checked", true);
        $("#CopLocRHS").attr("disabled", true);


    }
    else {
        $("#CopLocRear").prop("checked", true);
        $("#CopLocRear").attr("disabled", true);
        $("#CopLocLHS").prop("checked", false);
        $("#CopLocLHS").removeAttr("disabled");
        $("#CopLocRHS").prop("checked", false);
        $("#CopLocRHS").removeAttr("disabled");

    }
}

function changeHeadRoom() {
    var carheight = parseInt($("#CarHeight").val());

    if ($("#LiftType").val() == "DomusLift") {
        $("#Headroom").val(carheight + 450);
    }
    else if ($("#LiftType").val() == "DomusXL") {
        $("#Headroom").val(carheight + 500);
    }
    else if ($("#LiftType").val() == "Domus Evolution") {
        $("#Headroom").val(carheight + 650);
    }
    else if ($("#LiftType").val() == "Domus Spirit") {
        $("#Headroom").val(carheight + 450);
    }
    else {
        $("#Headroom").val(carheight + 500);
    }

}

function setWidthReadonly() {

    var model1 = $("#liftModel").val().split("/");

    if (model1[1] == "Special" || model1[1] == "small") {

        if (model1[1] == "Special") {
            $("#IntCarSizeWide").attr('readonly', false);
            $("#IntCarSizeDeep").attr('readonly', false);
            $("#IntCarSizeWidth").attr('readonly', false);
            $("#Door1SizeWide").attr('readonly', false);
            $("#Door2SizeWide").attr('readonly', false);

        }
        else {
            $("#IntCarSizeWide").attr('readonly', true);
            $("#IntCarSizeDeep").attr('readonly', true);
            $("#IntCarSizeWidth").attr('readonly', true);
            $("#Door1SizeWide").attr('readonly', true);
            $("#Door2SizeWide").attr('readonly', true);

        }
    }
    else {
        if ($("#liftModel").val().indexOf("Special") >= 0) {

            $("#IntCarSizeWide").attr('readonly', false);
            $("#IntCarSizeDeep").attr('readonly', false);
            $("#IntCarSizeWidth").attr('readonly', false);
            $("#Door1SizeWide").attr('readonly', false);
            $("#Door2SizeWide").attr('readonly', false);

        }
        else {

            $("#IntCarSizeWide").attr('readonly', true);
            $("#IntCarSizeDeep").attr('readonly', true);
            $("#IntCarSizeWidth").attr('readonly', true);
            $("#Door1SizeWide").attr('readonly', true);
            $("#Door2SizeWide").attr('readonly', true);
        }

    }
}

function checkAlllevel() {
    if ($('#Part12').is(":checked")) {
        if ($('#NoOfFloors').val() == 2) {
            $('#AllLevels').prop("checked", false);;
            $("#Gong").prop("checked", false);
            $("#VoiceSynt").prop("checked", false);
            $('#CarDisplayTypeLoc').val("No Display");
        }
        else {
            $('#AllLevels').prop("checked", true);
            $('#CarDisplayTypeLoc').val("Icaro blue");

            $("#Gong").prop("checked", true);
            $("#VoiceSynt").prop("checked", true);
        }
        $('#Phone').find('option').filter(function () {
            return this.text === 'Handsfree';
        }).attr('selected', 'selected');
    }
    else {
        $('#AllLevels').prop("checked", false);
    }
}

function Rule1() {
    if ($('#codeComplence').val() == 'Part 15' & $('#LiftType').val() == 'DomusLift') {
        if ($('#entranceType').val() == 'Front entrance') {
            $("#liftModel").html('');
            $("#liftModel").append('<option value="1C/8">1C/8</option>');
            $("#liftModel").trigger('change');
        }
        if ($('#entranceType').val() == 'Front & Rear entrance') {
            $("#liftModel").html('');
            $("#liftModel").append('<option value="2P/8">2P/8</option>');
            $("#liftModel").trigger('change');
        }
    }
}

function Rule2() {

    if ($('#codeComplence').val() == 'Part 15') {

        if ($('#entranceType').val() == 'Front entrance') {
            $("#NoOfFloors").html('');
            $("#NoOfFloors").append('<option value="2">2</option>');
        }
        if ($('#entranceType').val() == 'Front & Rear entrance') {

            $("#NoOfFloors").html('');
            $("#NoOfFloors").append('<option value="2">2</option>');
            $("#NoOfFloors").append('<option value="3">3</option>');
        }
    }
    else {
        $("#NoOfFloors").html('');
        $("#NoOfFloors").append('<option value="2">2</option>');
        $("#NoOfFloors").append('<option value="3">3</option>');
        $("#NoOfFloors").append('<option value="4">4</option>');
        $("#NoOfFloors").append('<option value="5">5</option>');
    }
}

function Rule3() {

    /*
    Added this rule for row 163 but commented for Row 245
    */
    /*
        if ($("#LiftType").val() == "Domus Evolution" && $("#liftModel").val() == "EVO-1C/2T") {
        $('#ShaftSizeWide').val(1550);
    }*/


}

function Rule4() {


    if ($("#liftModel").val().indexOf("Special") > 0) {

        if ($('#IntCarSizeWide').val() == 'N/A' || $('#IntCarSizeWide').val() == '') {
        $('#IntCarSizeWide').val('custom...');
        }
        if ($('#IntCarSizeDeep').val() == 'N/A' || $('#IntCarSizeDeep').val() == '') {
            $('#IntCarSizeDeep').val('custom...');
        }
        if ($('#ShaftSizeWide').val() == 'N/A' || $('#ShaftSizeWide').val() == '') {
            $('#ShaftSizeWide').val('custom...');
        }
        if ($('#ShaftSizeDeep').val() == 'N/A' || $('#ShaftSizeDeep').val() == '') {
            $('#ShaftSizeDeep').val('custom...');
        }
        if ($('#Door1SizeWide').val() == 'N/A' || $('#Door1SizeWide').val() == '') {
            $('#Door1SizeWide').val('custom...');
        }
        //        $('#Door1SizeDeep').val('custom...');
        if ($('#entranceType').val() != 'Front entrance') {
            if ($('#Door2SizeWide').val() == 'N/A' || $('#Door2SizeWide').val() == '') {
                $('#Door2SizeWide').val('custom...');
            }
            //            $('#Door2SizeDeep').val('custom...');
        }
    }
}

function Rule5() {

    if ($("#entranceType").val() == "Front & Rear entrance" ||
        $("#entranceType").val() == "Front & Adjacent – Left" ||
            $("#entranceType").val() == "Front & Adjacent – Right") {
        $('#DoorEntType3').val('Second entrance');
    }


}

function LopLocationChange() {

    var temp = this.id;
    var number = temp.replace("LopLocation", "");
    $("#LopFinish" + number).html('')
    if ($(this).val() == "Remote") {
        $("#LopFinish" + number).append('<option value="Brushed Stainless Steel superflat plate">Brushed Stainless Steel superflat plate</option>');
        $("#LopFinish" + number).append('<option value="Mirror stainless steel super flat plate">Mirror stainless steel super flat plate</option>');

        $("#LopFinish" + number).append('<option value="Gold Steel 138 superflat plate">Gold Steel 138 superflat plate</option>');

    }
    else {

        $("#LopFinish" + number).append('<option value="Brushed stainless steel plate">Brushed stainless steel plate</option>');
        $("#LopFinish" + number).append('<option value="Mirror stainless steel plate">Mirror stainless steel plate</option>');
        $("#LopFinish" + number).append('<option value="Gold Steel 138 plate">Gold Steel 138 plate</option>');
        $("#LopFinish" + number).append('<option value="Aluminium plate">Aluminium plate</option>');
        $("#LopFinish" + number).append('<option value="Brushed Stainless Steel superflat plate">Brushed Stainless Steel superflat plate</option>');
        $("#LopFinish" + number).append('<option value="Mirror stainless steel super flat plate">Mirror stainless steel super flat plate</option>');
        $("#LopFinish" + number).append('<option value="Gold Steel 138 superflat plate">Gold Steel 138 superflat plate</option>');

    }
}

function changeLdfDoorType(element) {

    var temp = this;
    var idString = this.id;
    var number = idString.replace("LDFDoorType", "");
    //  alert("number " + number);
    $.ajax({
        url: $("#GetLDFDoorFinish").val(),
        type: 'POST',
        data: {
            Value: $("#LiftType").val(),

            Id: $(this).val(),
        },
        success: function (vv) {

            var LDFDoorFinish = "#LDFDoorFinish" + number;
            var LDFFrameFinish = "#LDFFrameFinish" + number;

            $(LDFDoorFinish).html('');
            $(LDFFrameFinish).html('');
            $.each(vv, function (i, states) {
                $(LDFDoorFinish).append('<option value="' + states.Value + '">' +
                     states.Text + '</option>');
                $(LDFFrameFinish).append('<option value="' + states.Value + '">' +
                   states.Text + '</option>');

                // here we are adding option for States

            });
            //  $('#LiftType').val(vv[0].Value).trigger('change');
            // $('#liftModel').val(vv[0].Value).trigger('change');
            $(LDFDoorFinish).find('option').filter(function () {
                return this.text === 'Brushed Stainless Steel 127';
            }).attr('selected', 'selected');
            $(LDFFrameFinish).find('option').filter(function () {
                return this.text === 'Brushed Stainless Steel 127';
            }).attr('selected', 'selected');
        },
        error: function (xhr) { alert("Something seems Wrong"); }
    });
    setLDFEmbDoorClose(number);
}

function initHide() {
    $('#special').hide();
    $('#SpecialRAL').hide();
    $('#Level3H').hide();
    $('#Level4H').hide();
    $('#Level5H').hide();
    $('#DivDoorEntType2').hide();
    $('#DivDoorEntType4').hide();
    $('#DivDoorEntType5').hide();
    $('#DivDoorEntType6').hide();
    $('#DivDoorEntType7').hide();
    $('#DivDoorEntType8').hide();
    $('#DivDoorEntType9').hide();
    $('#DivDoorEntType10').hide();

    $('#DivLDFDoorType2').hide();
    $('#DivLDFDoorType4').hide();
    $('#DivLDFDoorType5').hide();
    $('#DivLDFDoorType6').hide();
    $('#DivLDFDoorType7').hide();
    $('#DivLDFDoorType8').hide();
    $('#DivLDFDoorType9').hide();
    $('#DivLDFDoorType10').hide();
}

function initsetup1()
{
    $('#DivDoor2').hide();
//    $('#DiSecondEntLanDoor').hide();

    $('#FtoFD2').hide();
    $('#FtoFD3').hide();
    $('#FtoFD4').hide();

    $('#FToF1').val($('#FtoFStart1').val());
    $('#FToF3').val($('#FtoFFinish1').val());
    $('#FToFD1').val($('#FtoFStart1').val());
    $('#FToFD3').val($('#FtoFFinish1').val());
    $('#FToF5').val($('#FtoFFinish2').val());
    $('#FToFD5').val($('#FtoFFinish2').val());
    $('#FToF7').val($('#FtoFFinish3').val());
    $('#FToFD7').val($('#FtoFFinish3').val());
    $('#FToF9').val($('#FtoFFinish4').val());
    $('#FToFD9').val($('#FtoFFinish4').val());

}

function disableHandrailLoc() {

    if ($("#HandRailType").val() == "No Handrail") {
        $('#HandRailLocLHS').attr("disabled", true);
        $('#HandRailLocRHS').attr("disabled", true);
        $('#HandRailLocRear').attr("disabled", true);
    }
    else {
        $('#HandRailLocLHS').attr("disabled", false);
        $('#HandRailLocRHS').attr("disabled", false);
        $('#HandRailLocRear').attr("disabled", false);
        if ($('#loadBearingWall').val() == "Left") {
            $("#HandRailLocRHS").prop("checked", false);
            $("#HandRailLocRear").prop("checked", false);
            $("#HandRailLocLHS").prop("checked", true);


        }
        else if ($(loadBearingWall).val() == "Right") {
            $("#HandRailLocLHS").prop("checked", false);
            $("#HandRailLocRear").prop("checked", false);
            $("#HandRailLocRHS").prop("checked", true);
        }
        else {
            $("#HandRailLocRear").prop("checked", true);
            $("#HandRailLocLHS").prop("checked", false);
            $("#HandRailLocRHS").prop("checked", false);

        }

    }
}

function setLDFEmbDoorClose(number) {
                                
    var type = $("#" + "LDFDoorType" + number).val().substring(0, 1);
    if (type == "B") {
        // $('#CopLocLHS').selected = true;
        $("#" + "LDFEmbDoorClose" + number).attr("disabled", false);

        $("#" + "LDFEmbDoorClose" + number).prop("checked", true);
    }
    else {
        $("#LDFEmbDoorClose" + number).prop("checked", false);
        $("#LDFEmbDoorClose" + number).attr("disabled", true);
    }
}

function changeNoOfLifts() {
    $('#nooflifts1').val($('#NoOfLifts').val());
    $('#nooflifts2').val($('#NoOfLifts').val());
    $('#nooflifts3').val($('#NoOfLifts').val());
    $('#SellingPrice1').val(parseFloat($('#SellingPrice').val() * $('#NoOfLifts').val()).toFixed(1));
    $('#Gst1').val(parseFloat($('#Gst').val() * $('#NoOfLifts').val()).toFixed(1));
    $('#TotalSellingPrice1').val(parseFloat($('#TotalSellingPrice').val() * $('#NoOfLifts').val()).toFixed(1));
}

function setHandrail() {

    if ($('#codeComplence').val() == "Part 18") {
        $("#HandRailType").html('');
        $("#HandRailType").append('<option value="No Handrail">No Handrail</option>');
        $("#HandRailType").append('<option value="Flat Natural Anodised Aluminium">Flat Natural Anodised Aluminium</option>');
        $("#HandRailType").append('<option value="Flat Gold Anodised Aluminium">Flat Gold Anodised Aluminium</option>');
        $("#HandRailType").append('<option value="Round Satin Stainless Steel">Round Satin Stainless Steel</option>');
        $("#HandRailType").append('<option value="Round Polished Stainless Steel">Round Polished Stainless Steel</option>');
        $("#HandRailType").append('<option value="Round Gold Stainless Steel">Round Gold Stainless Steel</option>');
        $("#HandRailType").append('<option value="Round stainless steel with rounded corners">Round stainless steel with rounded corners</option>');

    }
    else {
        $("#HandRailType").html('');
        $("#HandRailType").append('<option value="No Handrail">No Handrail</option>');
        $("#HandRailType").append('<option value="Round stainless steel with rounded corners">Round stainless steel with rounded corners</option>');
        if ($('#Part12').is(":checked")) {
            $("#HandRailType").val = "Round stainless steel with rounded corners";
        }
    }
}

function setSpeed() {

    $("#Speed").html('');

    if ($("#LiftType").val() == "DomusXL") {
        if ($('#codeComplence').val() == "Part 15") {
            $("#Speed").append('<option value="0.15">0.15</option>');
        }
        else {
            $("#Speed").append('<option value="0.25">0.25</option>');
            $("#Speed").append('<option value="0.15">0.15</option>');

            $("#Speed").append('<option value="0.3">0.3</option>');
        }
        if ($('#Speed').val() == "0.15") {
            $("#Pit").val("130");
        }
        else {
            $("#Pit").val("150");
        }

    }

    else if ($("#LiftType").val() == "DomusXL Spirit" || $("#LiftType").val() == "Domus Spirit") {
        $("#Speed").html('');
        $("#Speed").append('<option value="0.15">0.15</option>');
        $("#Pit").val("130");
    }
    else if ($("#LiftType").val() == "Domus Evolution") {

        if ($("#power").val() != "Three Phase") {
            $("#Speed").empty();
            $("#Speed").append('<option value="0.3">0.3</option>');
            $("#Speed").append('<option value="0.25">0.25</option>');
            $('#Speed').find('option').filter(function () {
                return this.text === '0.25';
            }).attr('selected', 'selected');
            $("#Pit").val("150");
            $('#CarDisplayType').val('Icaro blue');
        } else {
            $("#Speed").empty();
            $("#Speed").append('<option value="0.3">0.3</option>');
            $("#Pit").val("150");
        }

    }
    else if ($("#LiftType").val() == "DomusLift") {
        $("#Speed").append('<option value="0.25">0.25</option>');
        $("#Pit").val("130");
    }

}

function changeEntranceType() {
        var value = $('#entranceType').val();
    if ($('#ShaftType').val() === "Tower" | $('#ShaftType').val() === "Top Hat") {

        if ($('#LiftType').val() === "DomusXL Spirit" | $('#LiftType').val() === "Domus Spirit") {
            $('#entranceType').html('');
            $('#entranceType').append('<option value="Front entrance">Front entrance</option>');
            $('#entranceType').append('<option value="Front & Rear entrance">Front & Rear entrance</option>');
            if (value === "Front entrance" | value === "Front & Rear entrance") {
                $('#entranceType').val(value);
            }
        }
        else {
            if ($('#isType').val() === "Commercial") {

                $('#entranceType').html('');
                $('#entranceType').append('<option value="Front entrance">Front entrance</option>');
                $('#entranceType').append('<option value="Front & Rear entrance">Front & Rear entrance</option>');
                if (value === "Front entrance" | value === "Front & Rear entrance") {
                    $('#entranceType').val(value);
                }
            }
            else {

                $('#entranceType').html('');
                $('#entranceType').append('<option value="Front entrance">Front entrance</option>');
                $('#entranceType').append('<option value="Front & Rear entrance">Front & Rear entrance</option>');
                $('#entranceType').append('<option value="Front & Adjacent – Left">Front & Adjacent – Left</option>');
                $('#entranceType').append('<option value="Front & Adjacent – Right">Front & Adjacent – Right</option>');
                $('#entranceType').val(value);
            }
        }
    }
    else {
        var value = $('#entranceType').val();
        if ($('#isType').val() === "Commercial") {

            $('#entranceType').html('');
            $('#entranceType').append('<option value="Front entrance">Front entrance</option>');
            $('#entranceType').append('<option value="Front & Rear entrance">Front & Rear entrance</option>');
            if (value === "Front entrance" | value === "Front & Rear entrance") {
                $('#entranceType').val(value);
            }
        }
        else {
            $('#entranceType').html('');
            $('#entranceType').append('<option value="Front entrance">Front entrance</option>');
            $('#entranceType').append('<option value="Front & Rear entrance">Front & Rear entrance</option>');
            $('#entranceType').append('<option value="Front & Adjacent – Left">Front & Adjacent – Left</option>');
            $('#entranceType').append('<option value="Front & Adjacent – Right">Front & Adjacent – Right</option>');
            $('#entranceType').val(value);
        }

    }
 
}

function setProfileDefault() {

    $(Profile).find('option').filter(function () {
        return this.text === 'Anodised Auminium - natural';
    }).attr('selected', 'selected');
}

function onPitChange() {

    if ($("#Speed").val() == "0.25") {
        $('#Pit').val('130');
    } else {
        if ($("#Speed").val() == "0.3") {
            $('#Pit').val('150');
        }

    }

}