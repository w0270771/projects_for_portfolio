var imageWindow;

function writePopup(link){

	imageWindow.document.writeln('<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"');
	imageWindow.document.writeln('                        "http://www.w3.org/TR/html4/loose.dtd">');
	imageWindow.document.writeln('<html>');
	imageWindow.document.writeln('<head>');
	imageWindow.document.writeln('<title>'+link.getAttribute('imagedescription')+'</title>');
	imageWindow.document.writeln('<meta http-equiv="content-script-type" content="text/javascript">');
	imageWindow.document.writeln('<meta http-equiv="content-style-type" content="text/css">');
	imageWindow.document.writeln('<meta http-equiv="content-type" content="text/html;charset=iso-8859-1">');
	imageWindow.document.writeln('</head>');
	imageWindow.document.writeln('<body style="height:100%;margin:0;padding:0;text-align:center;overflow:hidden;">');
	imageWindow.document.writeln('<div style="width:100%;height:100%;overflow:auto;">');
	imageWindow.document.writeln('  <p style="margin:0;padding:0;">');
	imageWindow.document.writeln('    <img src="'+link.href+'" alt="'+link.getAttribute('imagedescription')+'" style="margin:0 auto;" width="'+link.getAttribute('imagewidth')+'" height="'+link.getAttribute('imageheight')+'">');
	imageWindow.document.writeln('  </p>');
	imageWindow.document.writeln('  <p style="margin:0;padding:5px;">');
	imageWindow.document.writeln('    <a href="#" onclick="window.close();">Close me.</a>');
	imageWindow.document.writeln('  </p>');
	imageWindow.document.writeln('</div>');
	imageWindow.document.writeln('</body>');
	imageWindow.document.writeln('</html>');
	imageWindow.document.close();

	imageWindow.focus();

}		// End of writePopup(link) function.



var links=document.getElementsByTagName("a");

function parsePage(){

  for(var n=0;n<links.length;n++){

    if(links[n].getAttribute('windowheight') && links[n].getAttribute('windowwidth') && links[n].getAttribute('imageheight') && links[n].getAttribute('imagewidth') && links[n].getAttribute('imagedescription')){

links[n].setAttribute('windowwidth',	Math.min(	parseInt(links[n].getAttribute('windowwidth')	),screen.width-40)	);
links[n].setAttribute('windowheight',	Math.min(	parseInt(links[n].getAttribute('windowheight')	),screen.height-60)	);

      links[n].onclick=function(){
        imageWindow=window.open('','newwin','resizable=1,width='+this.getAttribute('windowwidth')+',height='+this.getAttribute('windowheight'));
        writePopup(this);
        return false;
      }		// End of the function that is run onclick of a "pop-up link".

    }		// End if statement that checks link for a "pop-up link".

  }		// End for loop.

}		// End of parsePage() function.