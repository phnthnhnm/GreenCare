import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import RouterCustom from './router';
import "./styles/bootstrap.min.css";
import "./styles/style.css";

const rootElement = document.getElementById('root');
const root = ReactDOM.createRoot(rootElement);

root.render(

    <React.StrictMode>
      <BrowserRouter basename={process.env.PUBLIC_URL}>
        <RouterCustom>

        </RouterCustom>
      </BrowserRouter>
    </React.StrictMode>

);

  