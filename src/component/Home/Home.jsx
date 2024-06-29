import React, { useEffect, useState }from'react';

export const Home = () => {
  let[htmlFileString, setHtmlFileString] = useState();

  async function fetchHtml() {
    setHtmlFileString(await (await fetch(`Home.html`)).text());
  }
  useEffect(() => {
    fetchHtml();
  }, []);

  return(
    <div className="Home">
      <div dangerouslySetInnerHTML={{ __html: htmlFileString }}></div>
    </div>
  );
}

