const getGravatarName = (hash, id) => {    
    
    this.getName = res => {
        
        document.getElementById(id).innerHTML = res.entry[0].displayName;
    }
        var ggn = document.createElement('script'); 
        ggn.type = 'text/javascript';
        ggn.async 
        ggn.src = `https://www.gravatar.com/${hash}.json?callback=getName`;
        var ref = document.getElementById(id);
        ref.parentNode.appendChild(ggn);    
}