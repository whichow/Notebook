Matrix4x4 M = transform.localToWorldMatrix; //模型矩阵
Matrix4x4 V = camera.worldToCameraMatrix;   //视图矩阵
Matrix4x4 P = camera.projectionMatrix;      //投影矩阵

Matrix4x4 MVP = P*V*M;