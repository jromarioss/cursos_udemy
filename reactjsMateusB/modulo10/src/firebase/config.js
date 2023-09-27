import { initializeApp } from "firebase/app";
import { getFirestore} from "firebase/firestore";

const firebaseConfig = {
  apiKey: "AIzaSyDAryy38_A0mADGCKS5wgVfvr5aRiQJzqY",
  authDomain: "miniblog-489e3.firebaseapp.com",
  projectId: "miniblog-489e3",
  storageBucket: "miniblog-489e3.appspot.com",
  messagingSenderId: "426433465526",
  appId: "1:426433465526:web:d01da686c37969414c2a17"
};

const app = initializeApp(firebaseConfig);
const db = getFirestore(app);

export { db }