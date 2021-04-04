using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuild))]
public class Tower : MonoBehaviour
{
    private TowerBuild _towerBuild;
    private List<Block> _blocks;

    public event UnityAction<int> SizeUpdate;
    private void Start()
    {
        _towerBuild = GetComponent<TowerBuild>();
        _blocks = _towerBuild.Build();

        foreach (Block block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }

        SizeUpdate?.Invoke(_blocks.Count);
    }

    private void OnBulletHit(Block hitedBlock)
    {
        hitedBlock.BulletHit -= OnBulletHit;

        _blocks.Remove(hitedBlock);

        foreach(Block block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x,
                                                   block.transform.position.y - block.transform.localScale.y,
                                                   block.transform.position.z);
        }

        SizeUpdate?.Invoke(_blocks.Count);
    }
}
