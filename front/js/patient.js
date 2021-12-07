// FLIP CARD
function flip(event){
	var element = event.currentTarget;
	if (element.className === "my_profile_card") {
    if(element.style.transform == "rotateY(180deg)") {
      element.style.transform = "rotateY(0deg)";
    }
    else {
      element.style.transform = "rotateY(180deg)";
    }
  }
};