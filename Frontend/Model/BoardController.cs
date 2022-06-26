﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;
using System.Text.Json;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace IntroSE.Kanban.Frontend.Model
{

    public class BoardController
    {
        BoardControllerService bcs;


        public BoardController()
        {
            bcs = ServiceLayerFactory.GetInstance().BoardControllerService;
        }

        public ObservableCollection<Board> GetBoards(string email)
        {
            string Json = bcs.GetUserBoards(email);
            if(GetOperationState(Json) == true)
            {
                LinkedList<int> boards = JsonEncoder.BuildFromJson<Response<LinkedList<int>>>(Json).returnValue;
                ObservableCollection<Board> output = new ObservableCollection<Board>();
                foreach (int id in boards)
                {
                    string Json2 = bcs.GetBoardById(email, id);
                    if(GetOperationState(Json2) == true)
                    {
                        Board board = JsonEncoder.BuildFromJson<Response<Board>>(Json2).returnValue;
                        output.Add(board);
                        return output;
                    }  
                }
            }
            throw new ArgumentException("the user has no boards");             
        }

        private static bool GetOperationState(string json)
        {
            Response<object> res = JsonEncoder.BuildFromJson<Response<object>>(json);
            return res.operationState;
        }


    }
}
