import { useState } from 'react'
import './App.css'
import useAxios from './apis/app-axios-configuration'
import { ConfigProvider } from 'antd';
import { AppContext } from './hooks/context/app-bounding-context';
import AppRoutes from './routes';
import { AUTH_ROUTES } from './routes/auth.routes';
function App() {
  const [loading, setLoading] = useState(false);
  const [routes, setRoutes] = useState(AUTH_ROUTES);


  const contextValue = {
    loading: loading,
    setLoading: setLoading,
    axios: useAxios(setLoading),
    routes: routes,
    setRoutes: setRoutes
  }
  return (
    <ConfigProvider>
      <AppContext.Provider value={contextValue} >


        <AppRoutes />


      </AppContext.Provider>
    </ConfigProvider>
  )
}

export default App
