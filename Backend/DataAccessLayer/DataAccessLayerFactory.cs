﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class DataAccessLayerFactory
    {
        private static DataAccessLayerFactory instance = null;
        private BoardControllerDTO BCDTO;
        private TaskControllerDTO taskContollerDTO;
        private UserControllerDTO userControllerDTO;
        private SQLExecuter executer;

        private DataAccessLayerFactory()
        {
            BCDTO = new();
            taskControllerDTO = new();
            userControllerDTO = new();
            executer = new();
        }

        public BoardControllerDTO boardControllerDTO => BCDTO;
        public TaskControllerDTO TaskControllerDTO => taskControllerDTO;
        public UserControllerDTO UserControllerDTO => userControllerDTO;
        public SQLExecuter SQLExecuter => executer;

        public static DataAccessLayerFactory GetInstance()
        {
            if (instance == null) instance = new();
            return instance;
        }
    }
}