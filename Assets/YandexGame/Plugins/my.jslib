mergeInto(LibraryManager.library, {
	SaveExtern: function(date) {
		var dateString = UTF8ToString(date);
		var myobj = JSON.parse(dateString);
		player.setDate(myobj);
	},

	LoadExtern: function(){
		player.getDate().then(_date => {
			const myJSON = JSON.stringify(_date);
			myGameInstance.SendMessage("Progress", "SetPlayerInfo", myJSON);
		});
	},
});

