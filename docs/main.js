$(document).ready(function() {
  window.addEventListener(
    "dragover",
    function(evt) {
      evt.stopPropagation();
      evt.preventDefault();
    },
    false
  );
  window.addEventListener(
    "drop",
    function(evt) {
      evt.stopPropagation();
      evt.preventDefault();
    },
    false
  );
  $("#dropzone")
    .on("dragenter", function(evt) {
      evt.stopPropagation();
      evt.preventDefault();
    })
    .on("dragover", function(evt) {
      evt.stopPropagation();
      evt.preventDefault();
      //evt.dataTransfer.dropEffect = "copy"; // Explicitly show this is a copy.
    })
    .on("drop dragdrop", function(evt) {
      evt.stopPropagation();
      evt.preventDefault();
      ReadFile(evt.originalEvent.dataTransfer.files[0]);
      /*
      if (evt.dataTransfer.files.length > 1) {
        alert(
          "Please drop only one file at a time.  Processing the first file dropped."
        );
      }
      if (evt.dataTransfer.files[0].type != ".txt") {
        alert("Please use transaction ending in .txt");
      }
      $("#input").text(files[0].getData("text"));
      */
    });


    function ReadFile(file){
        var reader = new FileReader();
        var transaction = reader.readAsText(file);
        $('#input').text(transaction);
    };
});
