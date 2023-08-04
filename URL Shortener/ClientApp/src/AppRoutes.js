import { Home } from "./components/Home";
import { GetRoles } from "./components/GetRoles";
import GetUrls from "./components/GetUrls";
import LoginForm from "./components/LoginForm";
import ShortLinkInfo from "./components/ShortLinkInfo";
const AppRoutes = [
  {
    index: true,
    element: <GetUrls />
  },
    {
        path: '/get-roles',
        element:<GetRoles />
    },
    {
        path: '/shortLinkInfo',
        element: <ShortLinkInfo />
    },
    {
        path: '/login',
        element:<LoginForm/>
    },
];

export default AppRoutes;
