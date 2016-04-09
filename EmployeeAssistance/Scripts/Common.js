$(document).ready(function () {


    function updateContextualSelect(url, selector) {
        $.get(url, function (data) {
            $(selector).empty();
            $(data).each(function (i, val) {

                $(selector).append('<option value=' + val.Id + '>' + val.Value + '</option>');
            })
        });
    }


    function getStates(country, selector) {
        var url = "Reader/GetStates?country=" + encodeURIComponent(country);
        updateContextualSelect(url, selector);
    }



    function getCities(state, selector) {
        var url = "Reader/GetCities?state=" + encodeURIComponent(state);
        updateContextualSelect(url, selector);
    }

    function getCategories(country, state, city, selector) {
        var url = "Reader/GetCategories?";
        if (country != null && country != "")
            url = url + "country=" + encodeURIComponent(country) + "&";
        if (state != null && state != "")
            url = url + "state=" + encodeURIComponent(state) + "&";
        if (city != null)
            url = url + "city=" + encodeURIComponent(city);

        updateContextualSelect(url, selector);

    }

    function getSubCategories(category, selector) {
        var url = "Category/GetSubCategories?";

        if (category != null && category != "")
            url = url + "category=" + encodeURIComponent(category);

        updateContextualSelect(url, selector)
    }

    function updateLikes(likes,selector)
    {
        //Ajax Post and then increment the Likes

        
        var url = "Reader/UpdateLike?informationId=" + $(selector).val();
        $.get(url, function (data) {

            if (data != null && data.Value != null) {
                likeSelector = $(selector).parent().find(".like");
                if (likeSelector.length > 0) {
                    likeSelector.html(data.Value);
                }
            }
        });


        //if (category != null && category != "")
        //    url = url + "category=" + encodeURIComponent(category);
    }

    $("#ddCountry").on('change', function () {
        getStates(this.value, "#ddState");
    });

    $("#ddState").on('change', function () {
        getCities(this.value, "#ddCity");
    });

    //$("#ddCity").on('change', function () {
    //    getCategories($("#ddCountry").val(),$("#ddState").val(),this.value, "#ddCategory");
    //});

    $("#ddCategory").on('change', function () {
        getSubCategories(this.value, "#ddSubCategory");
    });

    $("#btnLikes").on('click', function () {
        var selector = this.closest("row").find(".information");
        updateLikes(this.value, selector);
    });
});
