import { useContext } from "react"; 
import { AuthContext } from "../hocs/AuthProvider";

const useAuth = () => {
  return useContext(AuthContext);
}

export { useAuth };