var banner = {
    init: function () {
        this.selectBanner();
    },

    selectBanner: function () {
        $('body').on('change', '#banners-list .banner-input', function () {
            var file = $(this).get(0).files;

            var data = new FormData;

            data.append("image", file);

            $.ajax({
                url: '/Admin/Products/Create',
                type: 'POST',
                contentType: false,
                processData: false,
                data: data,
                success: function (res) {
                    if (res.status === "Ok") {
                        window.location.href = res.url;
                    }
                    window.location.href.res.url;
                }
            })
        })
    }
}
