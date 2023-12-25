import { Link } from 'react-router-dom'
import EPULogo from '../assets/images/logo.svg'

const AppLogo = () => {



    return <Link to={'/'}>
        <img style={{  height: '100%', objectFit: 'contain' }} src={EPULogo}></img>
    </Link>
}
export default AppLogo