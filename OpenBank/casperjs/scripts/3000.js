//Wells Fargo

phantom.injectJs('./scripts/common.js');

function login() {
	sign_in = "https://www.wellsfargo.com"
	casper.start(sign_in, function() {
	  this.fill('form#frmSignon', {
	    userid: user_id,
	    password: password
	  }, true);
	});

	casper.wait(1000, function() {
    	//allow time for login redirect
	});

	casper.waitForSelector('body', function() {
	  this.echo("splash screen check...");
	  splash_exists = this.evaluate(function() {
	    return __utils__.exists('#online_wellsfargo_com_splash');
	  });
	  
	  if (splash_exists) {
	   this.echo("splash screen bypass...");
	  	this.click('input.secondary'); //"No Thanks"
	  }
	});
}