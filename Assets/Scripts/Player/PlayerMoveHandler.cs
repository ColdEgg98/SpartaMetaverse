using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMoveHandler : BaseHandler
{
    private Camera cam;

    protected override void Start()
    {
        base.Start();
        cam = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertial = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertial).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = cam.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
            lookDirection = Vector2.zero;
        else
            lookDirection = lookDirection.normalized;
    }
}
