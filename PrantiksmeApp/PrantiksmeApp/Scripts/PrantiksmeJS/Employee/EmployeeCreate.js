
$(document).ready(function() {

});

//For photo PreView And Edit
function previewPhoto() {
    var files = document.getElementById("EmployeePhoto").files;
    $("#NewPhotoPreview").empty();
    $("#ExPhotoPreview").hide();

    for (var i = 0; i < files.length; i++) {

        var extension = files[i].name.split('.').pop();
        if (extension == "jpg" || extension == "png" || extension == "jpeg" || extension == "bmp") {
            var File = files[i];
            ReadImage(File);
            $("#HidePhotoDiv").show();
        }
        else {
            failedMsg("Only Image File Allowed");
            $("#photos").val("");
            $("#ExPhotoPreview").show();
            $("#imgDescription").val("");

        }

    }
}

var ReadImage = function (file) {
    var reader = new FileReader;
    var image = new Image;
    reader.readAsDataURL(file);
    reader.onload = function (_file) {
        image.src = _file.target.result;
        image.onload = function () {
            var height = this.height;
            var width = this.width;
            var type = file.type;
            var size = (file.size / 1024);

            if (height <= 300 && width <= 300 && size <= 150 && type == "image/jpeg" ||
                type == "image/jpg" ||
                type == "image/png") {

                $("#NewPhotoPreview").append("<div class='col-md-12'><img src='" +
                    _file.target.result /*URL.createObjectURL(event.target.files[i])*/ +
                    "' height='150' width='150' ></div>");
                $("#imgDescription")
                    .text(getRound(size) + " KB " + " ( " + height + " X " + " " + width + " px ) " + " " + type);

            } else {

                failedMsg("Photo less or equal (300 X 300) pixel and maximum 150 KB.</br> Photo format JPEG/PNG");
                $("#photos").val("");
                $("#imgDescription").text("");
                $("#ExPhotoPreview").show();
            }

        };
    };
};