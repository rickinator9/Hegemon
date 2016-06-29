using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

namespace Assets.Source.Contexts.GameContext.Context
{

	public class GameRoot : ContextView {

		private void Awake()
		{
			GameContext gameContext = new GameContext(this);
		}
	}
}