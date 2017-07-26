function ReadData(obj) {

    document.getElementById('popDiv').style.display = 'block';
    document.getElementById('popIframe').style.display = 'block';
    document.getElementById('bg').style.display = 'block';
}
function closeDiv() {
    document.getElementById('popDiv').style.display = 'none';
    document.getElementById('bg').style.display = 'none';
    document.getElementById('popIframe').style.display = 'none';
    parent.window.location.reload();
}
function ReadBob(obj) {

    document.getElementById('bobDiv').style.display = 'block';
    document.getElementById('popIframe').style.display = 'block';
    document.getElementById('bg').style.display = 'block';
}
function closebob() {
    document.getElementById('bobDiv').style.display = 'none';
    document.getElementById('bg').style.display = 'none';
    document.getElementById('popIframe').style.display = 'none';
}