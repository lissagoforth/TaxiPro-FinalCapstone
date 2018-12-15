// Write your JavaScript code.
var checkboxes = $("input[type='checkbox']"),
    button = $("a.IU.btn.btn-default");

checkboxes.click(function () {
    button.attr("disabled", !checkboxes.is(":checked"));
    button.addClass("button");
    button.removeClass;
});


function prepVideos() {
    var videos = ["vid-1", "vid-2", "vid-3", "vid-4", "vid-5"];
    var i = 0;
    var visvId = videos[i];
    vid = document.getElementById(visvId);
    if (!vid) {
        vid.style.display = "block";
    }
}

function nextVideo(divId) {
    if (visvId === divId) {
        vid.style.display = "block";
    } else {
        vid.style.display = "none";
    }
    
    i++;
    }

function inputCheck() {

    // loop over questions
    // check for user input (answer selection)
    // if null throw alert "Number i has not been answered..."
    // if every question is answered addTest() (Allow submission)
}
