
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