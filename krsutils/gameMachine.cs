﻿using _4pictures1word.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _4pictures1word.krsutils
{
    public class gameMachine
    {
        public static Palabra[] RandomWord()
        {
            Palabra[] repertorio = JsonManager.GetJSONwords();

            return repertorio;
        }
    }
}