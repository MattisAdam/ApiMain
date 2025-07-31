import { QueryClient, QueryClientProvider } from 'react-query'
import ReactDOM from 'react-dom/client';
import React from 'react';
import { Provider } from 'react-redux';
import { store } from "./component/store";
import App from './pages/App';


const queryClient = new QueryClient();

const root = ReactDOM.createRoot(
    document.getElementById('root') as HTMLElement
);

root.render(
    <React.StrictMode>
        <Provider store={store} >
            <QueryClientProvider client={queryClient}>
                <App/>
            </QueryClientProvider>
        </Provider>
    </React.StrictMode>
)

