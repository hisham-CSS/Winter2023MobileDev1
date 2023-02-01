using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    public GameObject levelPiecePrefab;
    public Transform spawnStart;

    List<GameObject> levelPiecesPivot = new List<GameObject>();
    List<GameObject> levelPieces = new List<GameObject>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D boxCollider;

        GameObject firstPiecePivot = Instantiate(levelPiecePrefab, spawnStart.position, spawnStart.rotation);
        GameObject firstPiece = firstPiecePivot.transform.GetChild(0).gameObject;
        boxCollider = firstPiece.GetComponent<BoxCollider2D>();

        GameObject secondPiecePivot = Instantiate(levelPiecePrefab, firstPiecePivot.transform.position + (Vector3)boxCollider.offset + new Vector3(firstPiece.transform.localScale.x, 0, 0), firstPiece.transform.rotation);
        GameObject secondPiece = secondPiecePivot.transform.GetChild(0).gameObject;
        boxCollider = secondPiece.GetComponent<BoxCollider2D>();


        GameObject thirdPiecePivot = Instantiate(levelPiecePrefab, secondPiecePivot.transform.position + (Vector3)boxCollider.offset + new Vector3(secondPiece.transform.localScale.x, 0, 0), secondPiece.transform.rotation);
        GameObject thirdPiece = thirdPiecePivot.transform.GetChild(0).gameObject;

        firstPiecePivot.GetComponent<PlatformScroll>().levelGenerator = this;
        secondPiecePivot.GetComponent<PlatformScroll>().levelGenerator = this;
        thirdPiecePivot.GetComponent<PlatformScroll>().levelGenerator = this;

        levelPieces.Add(firstPiece);
        levelPieces.Add(secondPiece);
        levelPieces.Add(thirdPiece);

        levelPiecesPivot.Add(firstPiecePivot);
        levelPiecesPivot.Add(secondPiecePivot);
        levelPiecesPivot.Add(thirdPiecePivot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DequeuePiece()
    {
        levelPieces.RemoveAt(0);
        levelPiecesPivot.RemoveAt(0);

        BoxCollider2D boxCollider;
        boxCollider = levelPieces[levelPieces.Count - 1].GetComponent<BoxCollider2D>();

        GameObject newPiecePivot = Instantiate(levelPiecePrefab, levelPiecesPivot[levelPiecesPivot.Count - 1].transform.position + (Vector3)boxCollider.offset + new Vector3(levelPieces[levelPieces.Count - 1].transform.localScale.x, 0, 0), levelPieces[levelPieces.Count - 1].transform.rotation);
        GameObject newPiece = newPiecePivot.transform.GetChild(0).gameObject;

        newPiecePivot.GetComponent<PlatformScroll>().levelGenerator = this;

        levelPieces.Add(newPiece);
        levelPiecesPivot.Add(newPiecePivot);


    }
}
