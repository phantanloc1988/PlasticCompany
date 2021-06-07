
var createProduct = {
    init: function () {
        createProduct.validate();
    },

    submitForm: function () {
        var locationDescription = $('#create-product-form .note-editable');

        var name = $('input[name="txtName"]').val();
        var sku = $('input[name="txtSku"]').val();
        var price = $('input[name="numPrice"]').val();
        var description = locationDescription.html();
        var descriptionImages = locationDescription.find('p img');
        var imageFiles = $('#formFile').get(0).files;

        //Add Info Product
        var product = {
            Name: name,
            Sku: sku,
            Price: parseInt(price),
            Description: description,
        };

        var data = new FormData();

        data.append("Product", JSON.stringify(product));

        //Add Image File
        data.append("MainImage", imageFiles[0])
               
        //Add Des Image file                
        if (descriptionImages.length >= 1) {
            for (var i = 0; i < descriptionImages.length; i++) {
                var name = "DesImage" + i;
                var uri = descriptionImages[i].currentSrc;
                var fileName = descriptionImages[0].dataset.filename;

                // convert uri to File
                var file = this.convertToFile(uri, fileName);

                data.append(name, file)                
            };
        } 

        $.ajax({
            url: '/Admin/Products/Create',
            type: 'POST',
            contentType: false,
            processData: false,
            data: data,
            success: function (res) {
                console.log(res)
            }
        })
    },

    validate: function () {
        $('#create-product-form').validate({
            rules: {
                txtName: { required: true },
                numPrice: { required: true },
            },
            messages: {
                txtName: { required: "Vui lòng điền tên sản phẩm" },
                numPrice: { required: "Vui lòng điền giá sản phẩm" },
            },
            submitHandler: function () {
                createProduct.submitForm()
            }
        })
    },

    convertToFile: function convert_URI_to_file(URI, filename) {
        var arr = URI.split(','), mime = arr[0].match(/:(.*?);/)[1],
            bstr = atob(arr[1]), n = bstr.length, u8arr = new Uint8Array(n);
        while (n--) {
            u8arr[n] = bstr.charCodeAt(n);
        }
        return new File([u8arr], filename, { type: mime });
    }

}



var textEditor = {
    init: function () {
        console.log('edit')
        this.editor();
    },

    editor: function () {
        $('#summernote').summernote();
    }
}

textEditor.init();
createProduct.init();