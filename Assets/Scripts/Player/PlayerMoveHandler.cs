using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMoveHandler : BaseHandler
{
    private Camera cam { get; set; }

    protected override void Start()
    {
        base.Start();
        if (cam == null)
            cam = Camera.main;
    }

    protected override void HandleAction()
    {
        if (cam != null)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertial = Input.GetAxisRaw("Vertical");
            movementDirection = new Vector2(horizontal, vertial).normalized;

            Vector2 mousePosition = Input.mousePosition;
            Vector2 worldPos = cam.ScreenToWorldPoint(mousePosition);
            lookDirection = (worldPos - (Vector2)transform.position);
        }
        else if (cam != null)
            cam = Camera.main;

        if (lookDirection.magnitude < .9f)
            lookDirection = Vector2.zero;
        else
            lookDirection = lookDirection.normalized;
    }
}
