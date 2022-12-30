import React from 'react';
import { createRoot } from 'react-dom/client';
import { Provider } from 'react-redux';
import { PersistGate } from 'redux-persist/integration/react';
import { persistStore } from 'redux-persist';
import { ConfigProvider } from 'antd';
import { ThemeConfig } from 'antd/es/config-provider/context';
import { Locale } from 'antd/es/locale';
import { store } from '@app/store';
import App from '@app/app';

import 'bootstrap/dist/css/bootstrap.min.css';
import styleVars from '@app/scss/export.module.scss';

const persistor = persistStore(store);
const root = createRoot(document.querySelector('#root')!);

const ambiTheme: ThemeConfig = {
    token: {
        colorPrimary: styleVars.colorMain,
        fontFamily: styleVars.fontMain
    }
};

const browserLocale: Locale = {
    locale: window.navigator.language ? window.navigator.language : 'en-US'
};

root.render(
    <React.StrictMode>
        <Provider store={store}>
            <PersistGate loading={null} persistor={persistor}>
                <ConfigProvider theme={ambiTheme} locale={browserLocale}>
                    <App />
                </ConfigProvider>
            </PersistGate>
        </Provider>
    </React.StrictMode>
);