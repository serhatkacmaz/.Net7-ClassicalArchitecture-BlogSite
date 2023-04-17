//-> Login Active Panel
const signUpButton = document.getElementById('signUp');
const signInButton = document.getElementById('signIn');
const container = document.getElementById('container');

signUpButton.addEventListener('click', () => {
	container.classList.add("right-panel-active");
});

signInButton.addEventListener('click', () => {
	container.classList.remove("right-panel-active");
});


//-> login Modal Click
function closeLoginModal() {
	document.getElementById("r_Name").value = "";
	document.getElementById("r_Email").value = "";
	document.getElementById("r_Password").value = "";

	document.getElementById("l_Email").value = "";
	document.getElementById("l_Password").value = "";
}

document.getElementById("loginRegisterBtn").addEventListener("click", closeLoginModal);